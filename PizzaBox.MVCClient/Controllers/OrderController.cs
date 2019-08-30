using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;
using PizzaBox.MVCClient.Models;
using pdb = PizzaBox.Data.Entities;

namespace PizzaBox.MVCClient.Controllers
{
    public class OrderController : Controller
    {
        public Location Store { get; set; }        
        public pdb.PizzaBoxDB2Context _db = new pdb.PizzaBoxDB2Context();
        public OrderViewModel orderModel = new OrderViewModel();

        public IActionResult Index()
        {
            foreach (var i in _db.Location.ToList())
            {
                orderModel.Location.Add(new Location(i.Name,i.Address,i.Address2,i.ZipCode,i.City,i.State));
            }
            Store = orderModel.Location.ElementAt(0);

            orderModel.Crust = Store.Crust;
            orderModel.Size = Store.PizzaSizes;
            orderModel.Toppings = Store.StoreToppings;

            return View(orderModel);
        }
    }
}