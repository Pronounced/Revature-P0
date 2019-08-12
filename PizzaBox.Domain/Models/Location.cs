using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Location : NameAndAddress
    {
        public List<string> storeAddress = new List<string>();
        private List<Pizza> pizzaList = new List<Pizza>();

        public Location(string name, string addr, string addr2, string zip, string city, string state)
        {
            Name = name;
            Address = addr;
            Address2 = addr2;
            ZipCode = zip;
            City = city;
            State = state;

            storeAddress.Add(Name);
            storeAddress.Add(Address);
            storeAddress.Add(Address2);
            storeAddress.Add(ZipCode);
            storeAddress.Add(City);
            storeAddress.Add(State);            
        }

        public void Deliver(int size, List<string> list)
        {
            List<string> cloneList = new List<string>(list);
            Pizza newPizza = new Pizza(size, cloneList);
            pizzaList.Add(newPizza);
        }

        public void AddCustomer(string name, string addr, string addr2, string zip, string city, string state)
        {
            User newCustomer = new User(name, addr, addr2, zip, city, state);
        }

        public void PrintPizza()
        {
            pizzaList.ForEach(Console.WriteLine);
        }
    }
}