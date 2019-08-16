using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Orders
    {
        public string NameOfCustomer { get; }
        public decimal Price { get; set; }
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

        public decimal calculateOrderPrice()
        {
            decimal total = 0;

            foreach (Pizza i in Pizzas)
            {
                total += i.calculatePizzaPrice();
            }

            Price = total;
            return total;
        }

        public void AddPizzaToOrder(Pizza p)
        {
            if((Pizzas.Count + 1) > 100)
            {
                return;
            }

            if((calculateOrderPrice() + p.calculatePizzaPrice()) > 5000)
            {
                return;
            }
            calculateOrderPrice();
            Pizzas.Add(p);
        }

        public void PrintPizza()
        {
            Pizzas.ForEach(Console.WriteLine);
        }

        public override string ToString()
        {
            List<string> orderPizzas = new List<string>();
            foreach (Pizza i in Pizzas)
            {
                orderPizzas.Add(i.ToString());
            }
            string dollars = Price.ToString("C");
            return $"ORDER: \nName: {NameOfCustomer} \nPrice: {dollars} \nPizzas: \n{String.Join("\n", orderPizzas.ToArray())}";
        }   
    }
}