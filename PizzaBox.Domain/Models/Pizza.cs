using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBox.Domain.Models
{
    public class Pizza
    {
        public string PizzaSize { get; }

        private List<string> toppings;

        public List<string> Toppings
        {
            get
            {
                return toppings;
            }

            protected set
            {
                toppings = value;
            }
        }

        public IDictionary<string, double> PizzaSizes { get => pizzaSizes; set => pizzaSizes = value; }

        private IDictionary<string, double> pizzaSizes = new Dictionary<string, double>()
        {
            {"Small", 5.00}, 
            {"Medium", 7.00}, 
            {"Large", 9.00}
        };

        public Pizza(int size, List<string> list)
        {
            PizzaSize = PizzaSizes.Keys.ElementAt(size - 1);
            Toppings = list;
        }

        public double calculatePrice()
        {
            double price;
            PizzaSizes.TryGetValue(PizzaSize, out price);      
            return (1.00 * Toppings.Count) + price;
        }

        public override string ToString()
        {
            return $"PIZZA: Size: {PizzaSize}, Toppings: {String.Join(" ", Toppings.ToArray())} ";
        }
    }
}