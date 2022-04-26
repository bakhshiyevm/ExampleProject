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


        [Route("/Main")]
        public IActionResult Index()
        {
            return View();
        }


    }
}
