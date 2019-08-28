using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using Microsoft.EntityFrameworkCore;
using DataB = PizzaBox.Data.Entities;

namespace PizzaBox.Domain.Models
{
    public class Order
    {
        public string UsernameOfCustomer { get; }
        public decimal Price { get; set; } 

        public List<ABasePizza> Pizzas{ get; set; }

        public DateTime OrderTime { get; set; }

        DataB.PizzaBoxDB2Context db = new DataB.PizzaBoxDB2Context();


        public Order(string user)
        {
            UsernameOfCustomer = user;
            Price = 0;
            Pizzas = new List<ABasePizza>();
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
            return $"\nORDER: \nName: {UsernameOfCustomer} \nPrice: {dollars} \nPizzas: {String.Join("\n", orderPizzas.ToArray())}";
        }   
    }
}