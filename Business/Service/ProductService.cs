using AutoMapper;
using Business.IService;
using DataAccess.Entities;
using DTO;
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
        public ProductService(IRepository<Product> repository, IMapper mapper) 
            : base(repository, mapper)
        {

        }
        public IEnumerable<ProductDTO> GetProductByCategory(int catId)
        {
            var entites = repository.Find(x => x.CategoryId == catId);
            var products = mapper.Map<IEnumerable<ProductDTO>>(entites);
            return products;
        }

        public void AddToCart(int id, int userId)
        {


        }
    }
}
