using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Orders
    {
        public string UsernameOfCustomer { get; }
        public decimal Price { get; set; }
        private List<ABasePizza> pizzas = new List<ABasePizza>();

        public List<ABasePizza> Pizzas
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

        public Orders(string user)
        {
            UsernameOfCustomer = user;
            Price = 0;
        }

        public decimal calculateOrderPrice()
        {
            decimal total = 0;

            foreach (ABasePizza i in Pizzas)
            {
                total += i.calculatePizzaPrice();
            }

            Price = total;
            return total;
        }

        public void AddPizzaToOrder(ABasePizza p)
        {
            if((Pizzas.Count + 1) > 100)
            {
                return;
            }

            if((calculateOrderPrice() + p.calculatePizzaPrice()) > 5000)
            {
                return;
            }
            Pizzas.Add(p);
            calculateOrderPrice();
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
            return $"ORDER: \nName: {UsernameOfCustomer} \nPrice: {dollars} \nPizzas: \n{String.Join("\n", orderPizzas.ToArray())}";
        }   
    }
}