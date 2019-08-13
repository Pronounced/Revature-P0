using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Orders
    {
        public string NameOfCustomer { get; }
        public int Price { get; }
        private List<Pizza> pizzas;

        public List<Pizza> Pizzas
        {
            get
            {
                return pizzas;
            }

            protected set
            {
                pizzas = value;
            }
        } 

        public Orders(Pizza p)
        {
            
        }

        public override string ToString()
        {
            return $"ORDER: Name: {NameOfCustomer}, Price: {Price}, Pizzas: {String.Join(" ", (object[])Pizzas.ToArray())}";
        }   
    }
}