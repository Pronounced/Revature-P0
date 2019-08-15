using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Pizza
    {
        public string PizzaSize { get; }

        private List<string> userToppings;

        public List<string> UserToppings
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

        private double crustPrice;
        public double CrustPrice { get => crustPrice; set => crustPrice = value; }

        
        public Pizza(String size, double crustPrice, List<string> list)
        {
            PizzaSize = size;
            UserToppings = list;
            CrustPrice = crustPrice;
        }

        public double calculatePizzaPrice()
        {
            return (1.00 * UserToppings.Count) + CrustPrice;
        }

        public override string ToString()
        {
            return $"Size: {PizzaSize}  Toppings: {String.Join(" ", UserToppings.ToArray())} ";
        }
    }
}