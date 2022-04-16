using Business.IService;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;

namespace Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService service;

        public LoginController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult SignIn(UserDTO user)
        {
            try
            {
                var x = service.Login(user);
                HttpContext.Session.SetString("id", x.Id.ToString());
                return RedirectToAction("Index","Home");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return SignIn();
            }
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            HttpContext.Session.Clear();
            return View("SignIn");
        }
        [HttpPost]
        public IActionResult SignUp(UserDTO user)
        {
            try
            {
                service.Create(user);
                ViewBag.Success = "Succesfully created!";
                return SignIn();
            }
            catch (Exception e)
            {
                
                ViewBag.Error = e.Message;
                return SignUp();
            }
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
