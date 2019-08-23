using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Data.Entities;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Recipes;

namespace PizzaBox.Domain.Models
{
    public class Location : ANameAndAddress
    {
        public static string OnlineUser { get; set; }

        public static List<User> CustomerList { get; protected set; }

        public List<Orders> OrderList { get; protected set; }

        public IDictionary<string, int> Inventory { get; protected set; }

        public List<ToppingsDb> StoreToppings { get; set; }

        public List<Size> PizzaSizes { get; set; }

        public List<Crust> Crust { get; set; }

        public List<string> Specialties { get; set; }

        Custom CustomPizza = new Custom();

        public Orders newOrder;

        PizzaBoxDB2Context db = new PizzaBoxDB2Context();


        public Location(string name, string addr, string addr2, string zip, string city, string state)
        {
            Name = name;
            Address = addr;
            Address2 = addr2;
            ZipCode = zip;
            City = city;
            State = state;


            StoreToppings = db.ToppingsDb.ToList();
            // new List<Toppings>()
            // {
            //     {new Toppings("Pepperoni", 1)},
            //     {new Toppings("Sausage", 1)},
            //     {new Toppings("Mushroom", 1)},
            //     {new Toppings("Olive", 1)},
            //     {new Toppings("Ham", 1)},
            //     {new Toppings("Pineapple", 1)}
            // };

            PizzaSizes = new List<Size>()
            {
                {new Size("Small", 5)},
                {new Size("Medium", 7)},
                {new Size("Large", 9)}
            };

            Crust = new List<Crust>()
            {
                {new Crust("NY", 0)},
                {new Crust("Chicago", 0)},
                {new Crust("Traditional", 0)}
            };

            Specialties = new List<string>()
            {
                {"Hawaiian"}
            };

            CustomerList = new List<User>();
            OrderList = new List<Orders>();
            Inventory = new Dictionary<string, int>();
            newOrder = new Orders(OnlineUser);

            Inventory.Add("Pepperoni", 50);
            Inventory.Add("Mushroom", 50);
            Inventory.Add("Sausage", 50);
            Inventory.Add("Ham", 50);
            Inventory.Add("Pineapple", 50);
            Inventory.Add("Olive", 50);
            Inventory.Add("Dough", 50);
        }

        public void AddCustomToOrder(int size, int crust, List<int> list)
        {
            ToppingsDb[] toppingsList = new ToppingsDb[Pizza.MAXTOPPINGS];

            foreach (int i in list)
            {
                toppingsList[i - 1] = StoreToppings.ElementAt(i - 1);
            }
            newOrder.AddPizzaToOrder(CustomPizza.Make(PizzaSizes.ElementAt(size - 1), Crust.ElementAt(crust - 1), toppingsList));
        }

        public void AddSpecialtyToOrder(ABasePizza p)
        {
            newOrder.AddPizzaToOrder(p);
        }

        public void AddCustomer(Login l, string name, string addr, string addr2, string zip, string city, string state)
        {
            User newCustomer = new User(l, name, addr, addr2, zip, city, state);
            CustomerList.Add(newCustomer);
        }

        public bool LoginCheck(string user, string pass)
        {
            foreach (var i in CustomerList)
            {
                if((user == i.UserLogin.UserName) && (pass == i.UserLogin.Password))
                {
                    newOrder = new Orders(user);
                    OnlineUser = user;
                    return true;
                }
            }
            return false;
        }

        public void AddOrderToList()
        {
            foreach (User i in CustomerList)
            {
                if(OnlineUser == i.UserLogin.UserName)
                {
                    i.LastOrder = DateTime.Now;
                    i.UserLocation = this;
                }
            }
            newOrder.OrderTime = DateTime.Now;
            OrderList.Add(newOrder);
            newOrder = new Orders(OnlineUser);
        }

        public bool CheckLastLocation()
        {
            foreach (User i in CustomerList)
            {
                if(OnlineUser == i.UserLogin.UserName && i.UserLocation != this && DateTime.Now < i.LastOrder.Add(new TimeSpan(24,0,0)))
                {
                    return false;
                }
            }
            return true;            
        }

        public bool CheckLastOrder()
        {
            foreach (User i in CustomerList)
            {
                if(OnlineUser == i.UserLogin.UserName && DateTime.Now < i.LastOrder.Add(new TimeSpan(2,0,0)))
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}