using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Location : NameAndAddress
    {
        private List<User> customerList = new List<User>();
        private List<Orders> orderList = new List<Orders>();

        IDictionary<string, int> inventory = new Dictionary<string, int>();

        public IDictionary<string, int> Inventory { get => inventory; set => inventory = value; }

        Orders newOrder = new Orders();

        public Location(string name, string addr, string addr2, string zip, string city, string state)
        {
            Name = name;
            Address = addr;
            Address2 = addr2;
            ZipCode = zip;
            City = city;
            State = state;          

            Inventory.Add("Pepperoni", 50);
            Inventory.Add("Mushroom", 50);
            Inventory.Add("Sausage", 50);
            Inventory.Add("Ham", 50);
            Inventory.Add("Bacon", 50);
            Inventory.Add("Spinich", 50);
        }

        public void AddToOrder(int size, List<string> list)
        {
            List<string> cloneList = new List<string>(list);
            Pizza newPizza = new Pizza(size, cloneList);
            newOrder.AddPizzaToOrder(newPizza);
            orderList.Add(newOrder);
        }

        public void AddCustomer(string name, string addr, string addr2, string zip, string city, string state)
        {
            User newCustomer = new User(name, addr, addr2, zip, city, state);
            customerList.Add(newCustomer);
        }

        public void PrintCustomers()
        {
            customerList.ForEach(Console.WriteLine);
        }

        public void PrintOrders()
        {
            orderList.ForEach(Console.WriteLine);
        }

        public void PrintInventory()
        {
            foreach (KeyValuePair<string, int> item in Inventory)
            {
                Console.WriteLine("Ingredient: {0}, Stock: {1}", item.Key, item.Value);
            }
        }
    }
}