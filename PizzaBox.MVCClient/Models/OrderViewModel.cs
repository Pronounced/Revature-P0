using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.MVCClient.Models
{
    public class OrderViewModel
    {
        public List<Location> Location { get; set; } 
        public List<Crust> Crust { get; set; }
        public List<Size> Size { get; set; }
        public List<Toppings> Toppings { get; set; }
        public int crustId { get; set; }
        public int sizeId { get; set; }
        public List<int> ToppingsId { get; set; }

        
        public OrderViewModel()
        {
            crustId = 0;
            sizeId = 0;
            ToppingsId = new List<int>(){};
            Location = new List<Location>(){};
            Crust = new List<Crust>(){};
            Size = new List<Size>(){};
            Toppings = new List<Toppings>(){};
        }
    }

}