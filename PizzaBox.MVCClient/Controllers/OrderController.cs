using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Recipes;
using PizzaBox.MVCClient.Models;
using pdb = PizzaBox.Data.Entities;

namespace PizzaBox.MVCClient.Controllers
{
    public class OrderController : Controller
    {
        public pdb.PizzaBoxDB2Context _db = new pdb.PizzaBoxDB2Context();
        public OrderViewModel orderModel = new OrderViewModel();

        [HttpGet]
        public IActionResult Index()
        {
            if(Location.OnlineUser != null)
            {                
                orderModel.Location = HomeController.StoreLocations;
                orderModel.Crust = HomeController.Store.Crust;
                orderModel.Size = HomeController.Store.PizzaSizes;
                orderModel.Toppings = HomeController.Store.StoreToppings;

                return View(orderModel);
            }
            return RedirectToAction("Index", "Home"); 
        }

        [HttpPost]
        public IActionResult Index(OrderViewModel ovm, List<int> tId)
        {
            HomeController.Store.AddCustomToOrder(ovm.sizeId, ovm.crustId, tId);
            return RedirectToAction("Index", "Order");
        }

        public IActionResult Confirm()
        {
            HomeController.Store.AddOrderToList();
            return RedirectToAction("Index", "OrderHistory");
        }
    }
}