using System;
using System.Collections.Generic;

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
        private List<string> pizzaSizes = new List<string>(){"Small", "Medium", "Large"};
        public List<string> PizzaSizes 
        { 
            get
            {
                return pizzaSizes;
            } 
        }
        List<string> toppingsList = new List<string>(){"Pepperoni","Mushroom","Sausage"};
        public List<string> ToppingsList 
        { 
            get
            {
                return toppingsList;
            } 
        }
        
        public Pizza(int size, List<string> list)
        {
            PizzaSize = pizzaSizes[size - 1];
            Toppings = list;
        }

        public override string ToString()
        {
            return $"PIZZA: Size: {PizzaSize}, Toppings: {String.Join(" ", Toppings.ToArray())} ";
        }
    }
}