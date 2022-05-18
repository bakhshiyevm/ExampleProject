using Business.IService;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService prodService;
        private readonly ICategoryService catService;

        public ProductsController(IProductService prodService, ICategoryService catService)
        {
            this.prodService = prodService;
            this.catService = catService;
        }
        [HttpGet]
        [Route("/Categories")]
        public IActionResult GetCategories()
        {
            //catService.Create(new CategoryDTO { Name="PC",Desc="Personal Computers" });
            //catService.Create(new CategoryDTO { Name="SmartPhone",Desc="Personal Computers" });
            //catService.Create(new CategoryDTO { Name="HeadPhone",Desc="Personal Computers" });
            //catService.Create(new CategoryDTO { Name="Laptop",Desc="Personal Computers" });
            
            var products = catService.Get();
            return View("Categories", products);
        }

        [HttpGet]
        [Route("/Categories/{catId}/Products")]
        public IActionResult GetProducts(int catId, SortOrder sortOrder = SortOrder.NameAsc, string name = null, int? page = 1 , int? pageSize = 25)
        {
            //var x = Convert.ToInt32((HttpContext.Session.GetString("id")??"0"));
            //prodService.Create(new ProductDTO { Name = "PC1",Price=123, CategoryId=1, Desc = "Personal Computers" });
            //prodService.Create(new ProductDTO { Name = "PC2",Price=12123, CategoryId = 1, Desc = "Personal Computers" });
            //prodService.Create(new ProductDTO { Name = "PC3",Price=1123, CategoryId = 1, Desc = "Personal Computers" });
            //prodService.Create(new ProductDTO { Name = "SmartPhone1", CategoryId = 2, Price = 1231123, Desc = "Personal Computers" });
            //prodService.Create(new ProductDTO { Name = "SmartPhone2", CategoryId = 2, Price = 11123, Desc = "Personal Computers" });
            //prodService.Create(new ProductDTO { Name = "SmartPhone3", CategoryId = 2, Price = 23, Desc = "Personal Computers" });
            //prodService.Create(new ProductDTO { Name = "HeadPhone1", CategoryId = 3, Price = 23, Desc = "Personal Computers" });
            //prodService.Create(new ProductDTO { Name = "HeadPhone2", CategoryId = 3, Price = 2322, Desc = "Personal Computers" });
            //prodService.Create(new ProductDTO { Name = "HeadPhone3", CategoryId = 3, Price = 2123, Desc = "Personal Computers" });
            //prodService.Create(new ProductDTO { Name = "Laptop1", CategoryId = 4, Price = 3, Desc = "Personal Computers" });
            //prodService.Create(new ProductDTO { Name = "Laptop2", CategoryId = 4, Price = 21123, Desc = "Personal Computers" });
            //prodService.Create(new ProductDTO { Name = "Laptop3", CategoryId = 4, Price = 21, Desc = "Personal Computers" });
            

            var products = prodService.GetProductByCategory(catId,name,page,pageSize);


            ViewData["NameSort"] = sortOrder == SortOrder.NameAsc ? SortOrder.NameDesc : SortOrder.NameAsc;
            ViewData["PriceSort"] = sortOrder == SortOrder.PriceAsc ? SortOrder.PriceDesc : SortOrder.PriceAsc;

            products = sortOrder switch
            {
                SortOrder.NameDesc => products.OrderByDescending(s => s.Name),
                SortOrder.PriceAsc => products.OrderBy(s => s.Price),
                SortOrder.PriceDesc => products.OrderByDescending(s => s.Price),

                _ => products.OrderBy(s => s.Name),
            };

            var pagedRs = new PagedResponse<ProductDTO>(page, pageSize,products);

            return View("Products", pagedRs);
        }
        [HttpGet]
        [Route("/Categories/Products/{id}")]
        public IActionResult GetProduct(int id)
        {

            var product = prodService.Get(id);


            return View("Product", product);
        }
        [HttpPost]
        public void AddToCart(int id)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("id"));
            prodService.AddToCart(id,userId);

            ViewBag.Success = "Successfuly added!";
            //return View("Product");
        }

        [HttpGet]
        public IActionResult Cart()
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("id"));
            var prods= prodService.GetCart( userId);

            return View("Cart",prods);
        }

        [HttpPost]
        public IActionResult Payment()
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("id"));
            var payment = prodService.Payment(userId);

            return View("Payment", payment);
        }

    }
}
