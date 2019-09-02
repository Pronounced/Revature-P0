using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using pdb = PizzaBox.Data.Entities;

namespace PizzaBox.MVCClient.Controllers
{
    public class OrderHistoryController : Controller
    {
        public pdb.PizzaBoxDB2Context _db = new pdb.PizzaBoxDB2Context();

        public IActionResult Index()
        {
            Order newOrder;
            var OrderList = new List<Order>();
            var userOrderList = new List<Order>();
            foreach (var i in _db.Orders.ToList())
            {
                newOrder = new Order(i.CustUserName)
                {
                    Price = i.Price,
                    OrderTime = i.OrderTime,
                };

                foreach (var x in _db.Pizza.Include("Size").Include("Crust").ToList())
                {
                    var dbToPizza = new Pizza(new Size(x.Size.Name, x.Size.Price, x.SizeId), new Crust(x.Crust.Name, x.Crust.Price, x.CrustId), new Toppings[Pizza.MAXTOPPINGS]);

                    int count = 0;
                    foreach (var t in _db.PizzaToppingsRel.Include("Toppings").ToList())
                    {
                        if(x.PizzaId == t.PizzaId)
                        {
                             dbToPizza.UserToppings[count] = new Toppings(t.Toppings.Name, t.Toppings.Price, t.Toppings.ToppingsId);
                             count++;
                        }
                    }

                    if(i.OrdersId == x.OrdersId)
                    {
                        newOrder.Pizzas.Add(dbToPizza);
                    }
                }

                OrderList.Add(newOrder);
            }

            foreach (Order i in Location.OrderList)
            {
                if(Location.OnlineUser == i.UsernameOfCustomer)
                {
                    userOrderList.Add(i);
                }
            }

            return View(userOrderList);
        }
    }
}