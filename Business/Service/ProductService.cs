using AutoMapper;
using Business.IService;
using DataAccess;
using DataAccess.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;
using Repo.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class ProductService : BaseService<ProductDTO, Product, ProductDTO>,
        IProductService
    {
        private readonly AppDbContext db;
        public ProductService(AppDbContext appDbContext, IRepository<Product> repository, IMapper mapper) 
            : base(repository, mapper)
        {
            db = appDbContext;
        }
        public IEnumerable<ProductDTO> GetProductByCategory(int catId, string name = null, int? page = 1, int? pageSize = 25)
        {
            var entites = repository.Find(x => x.CategoryId == catId);

            if (name != null)
            {
                entites = entites.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            
            }


            entites = entites.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);

            var products = mapper.Map<IEnumerable<ProductDTO>>(entites);
            return products;
        }

        public void AddToCart(int productId, int userId)
        {

            var product = repository.Get(productId);

            var user = db.Users.Find(userId);

            user.Products.Add(product);

            db.SaveChanges();

        }

        public IEnumerable<ProductDTO> GetCart(int userId)
        {//select * from Carts as p 
          //  join users as u on (p.userid = u.id)
            var user = db.Users.Find(userId);
            var allProds = db.Products.Include(x => x.Users).ToList();


            var cartProds = allProds.Where(x => x.Users.Contains(user));            
            // select * from allPords as ap
            //where ap.userid = 8
            
            var rs = mapper.Map<IEnumerable<ProductDTO>>(cartProds);
            return rs;
        }


        public PaymentDTO Payment(int userId)
        {
            var user = db.Users.Find(userId);
            var allProds = db.Products.Include(x => x.Users).ToList();
            var cartProds = allProds.Where(x => x.Users.Contains(user));
            var payment = new PaymentDTO();
            payment.Count = cartProds.Count();
            payment.Price = cartProds.Sum(x => x.Price);
            return payment;
        }
    }
}
