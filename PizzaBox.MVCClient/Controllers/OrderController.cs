using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;
using pdb = PizzaBox.Data.Entities;

namespace PizzaBox.MVCClient.Controllers
{
    public class OrderController : Controller
    {
        
        Location l = new Location("1","1","1","1","1","1");
        pdb.PizzaBoxDB2Context _db = new pdb.PizzaBoxDB2Context();

        public ViewResult Read()
        {
            return View(l.Crust);
        }
    }
}