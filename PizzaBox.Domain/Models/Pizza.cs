using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Pizza
    {
        public Size PizzaSize { get; set; }
        public Crust PizzaCrust { get; set; }

        private List<Toppings> userToppings;

        public List<Toppings> UserToppings
        {
            get
            {
                return userToppings;
            }

            protected set
            {
                userToppings = value;
            }
        }
        
        public Pizza(Size size, Crust crust, List<Toppings> list)
        {
            PizzaSize = size;
            UserToppings = list;
            PizzaCrust = crust;
        }

        public decimal calculatePizzaPrice()
        {
            decimal toppingsPrice = 0;
            foreach (Toppings i in UserToppings)
            {
                toppingsPrice = toppingsPrice + i.Price;
            }
            return (PizzaSize.Price + toppingsPrice);
        }

        public override string ToString()
        {
            List<string> pizzaToppings = new List<string>();
            foreach (Toppings i in UserToppings)
            {
                pizzaToppings.Add(i.Name);
            }
            return $"Size: {PizzaSize.Name} \nCrust: {PizzaCrust.Name}  \nToppings: {String.Join(" ", pizzaToppings.ToArray())} ";
        }
    }
}