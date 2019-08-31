using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;
using PizzaBox.MVCClient.Models;
using pdb = PizzaBox.Data.Entities;

namespace PizzaBox.MVCClient.Controllers
{
    public class RegisterController : Controller
    {
        public pdb.PizzaBoxDB2Context _db = new pdb.PizzaBoxDB2Context();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(RegisterViewModel rvm)
        {
            if(ModelState.IsValid)
            {
                HomeController.Store.AddCustomer(
                    new Login(rvm.Login.UserName, rvm.Login.Password),
                    rvm.User.Name,
                    rvm.User.Address,
                    rvm.User.Address2,
                    rvm.User.ZipCode,
                    rvm.User.City,
                    rvm.User.State);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}