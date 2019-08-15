using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBox.Domain.Models
{
    public class Location : NameAndAddress
    {
        private List<User> customerList = new List<User>();
        public List<User> CustomerList { get => customerList; protected set => customerList = value; }

        private List<Orders> orderList = new List<Orders>();
        public List<Orders> OrderList { get => orderList; protected set => orderList = value; }

        IDictionary<string, int> inventory = new Dictionary<string, int>();
        public IDictionary<string, int> Inventory { get => inventory; protected set => inventory = value; }

        private IDictionary<string, double> storeToppings = new Dictionary<string, double>()
        {
            {"Pepperoni", 1.00},
            {"Sausage", 1.00},
            {"Mushroom", 1.00},
            {"Olive", 1.00},
            {"Ham", 1.00},
            {"Pineapple", 1.00}
        };
        public IDictionary<string, double> StoreToppings { get => storeToppings; set => storeToppings = value; }

        public IDictionary<string, double> PizzaSizes { get => pizzaSizes; set => pizzaSizes = value; }
        private IDictionary<string, double> pizzaSizes = new Dictionary<string, double>()
        {
            {"Small", 5.00}, 
            {"Medium", 7.00}, 
            {"Large", 9.00}
        };

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
            OrderList.Add(newOrder);

        }

        public void AddToOrder(int size, List<string> list)
        {
            List<string> toppingsList = new List<string>();

            foreach (string i in list)
            {
                toppingsList.Add(StoreToppings.Keys.ElementAt(Int32.Parse(i) - 1));
            }
            Pizza newPizza = new Pizza(PizzaSizes.Keys.ElementAt(size - 1), PizzaSizes[PizzaSizes.Keys.ElementAt(size - 1)], toppingsList);
            newOrder.AddPizzaToOrder(newPizza);
        }

        public void AddCustomer(string name, string addr, string addr2, string zip, string city, string state)
        {
            User newCustomer = new User(name, addr, addr2, zip, city, state);
            CustomerList.Add(newCustomer);
        }
    }
}