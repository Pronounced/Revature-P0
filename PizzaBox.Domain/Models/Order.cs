using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Orders
    {
        public string NameOfCustomer { get; }
        public double Price { get; set; }
        private List<Pizza> pizzas = new List<Pizza>();

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

        public Orders()
        {
            NameOfCustomer = "Jarrett Green";
            Price = 0;
        }

        public double calculatePrice()
        {
            double total = 0;

            foreach (Pizza i in Pizzas)
            {
                total += i.calculatePrice();
            }

            Price = total;
            return total;
        }

        public void AddPizzaToOrder(Pizza p)
        {
            Pizzas.Add(p);
            calculatePrice();
        }

        public void PrintPizza()
        {
            Pizzas.ForEach(Console.WriteLine);
        }

        public override string ToString()
        {
            return $"ORDER: Name: {NameOfCustomer}, Price: {Price}, Pizzas: {String.Join(" ", (object[])Pizzas.ToArray())}";
        }   
    }
}