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
        public static List<Location> StoreLocations = new List<Location>();
      

        [HttpGet]
        public IActionResult Index()
        {
            StoreLocations = new List<Location>();
            foreach (var i in _db.Location.ToList())
            {
                StoreLocations.Add(new Location(i.Name,i.Address,i.Address2,i.ZipCode,i.City,i.State));
            }
            
            Store = StoreLocations.ElementAt(0);
            Location.OnlineUser = null;
            return View();
        }

        [HttpPost]
        public IActionResult Index(string user, string pass)
        {
            if(ModelState.IsValid)
            {
                foreach (var item in _db.Login.ToList())
                {
                    if(Store.LoginCheck(user, pass))
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
