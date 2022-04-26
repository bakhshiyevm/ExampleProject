﻿using Business.IService;
using DTO;
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

        [Route("/Categories/{catId}/Products")]
        public IActionResult GetProducts(int catId)
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
            var products = prodService.GetProductByCategory(catId);
            return View("Products", products);
        }


    }
}