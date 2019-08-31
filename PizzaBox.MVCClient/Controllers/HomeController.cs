using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;
using PizzaBox.MVCClient.Models;
using pdb = PizzaBox.Data.Entities;

namespace PizzaBox.MVCClient.Controllers
{
    public class HomeController : Controller
    {
        public pdb.PizzaBoxDB2Context _db = new pdb.PizzaBoxDB2Context();
        public static Location Store { get; set; }        

        [HttpGet]
        public IActionResult Index()
        {
            pdb.Location loc = _db.Location.ToList().ElementAt(0);
            Store = new Location(loc.Name, loc.Address, loc.Address2, loc.ZipCode, loc.City, loc.State);
            return View();
        }

        [HttpPost]
        public IActionResult Index(string user, string pass)
        {
            if(ModelState.IsValid)
            {
                foreach (var item in _db.Login.ToList())
                {
                    if(user == item.UserName && pass == item.Password)
                    {
                        return RedirectToAction("Index", "Order");
                    }
                }               
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
