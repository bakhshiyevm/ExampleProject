using DataAccess.Entities;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IService
{
    public interface IProductService : IBaseService<ProductDTO, Product,ProductDTO>
    {
        public IEnumerable<ProductDTO> GetProductByCategory(int catId,string name = null, int? page = 1, int? pageSize = 25);

        public void AddToCart(int productId, int userId);

        public IEnumerable<ProductDTO> GetCart(int userId);

        public PaymentDTO Payment(int userId);
    }
}
