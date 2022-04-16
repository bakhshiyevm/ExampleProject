using Business.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService service;

        public HomeController(IProductService service)
        {
            this.service = service;
        }

        [Route("/Main")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Products")]
        public IActionResult List()
        {
            //var x = Convert.ToInt32((HttpContext.Session.GetString("id")??"0"));

            var products = service.Get();
            return View("Products",products);
        }

    }
}
