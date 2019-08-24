using System;
using System.Collections.Generic;
using System.Linq;
using DataB = PizzaBox.Data.Entities;
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

        public List<Toppings> StoreToppings { get; set; }

        public List<Size> PizzaSizes { get; set; }

        public List<Crust> Crust { get; set; }

        public List<string> Specialties { get; set; }

        //Custom CustomPizza;

        public Orders newOrder;

        DataB.PizzaBoxDB2Context db = new DataB.PizzaBoxDB2Context();


        public Location(string name, string addr, string addr2, string zip, string city, string state)
        {
            Name = name;
            Address = addr;
            Address2 = addr2;
            ZipCode = zip;
            City = city;
            State = state;

            StoreToppings = new List<Toppings>();
            foreach (var i in db.ToppingsDb.ToList())
            {
                StoreToppings.Add(new Toppings(i.Name,i.Price));
            }

            PizzaSizes = new List<Size>();
            foreach (var i in db.Size.ToList())
            {
                PizzaSizes.Add(new Size(i.Name, i.Price));
            }

            Crust = new List<Crust>();
            foreach (var i in db.Crust.ToList())
            {
                Crust.Add(new Crust(i.Name, i.Price));
            }

            Specialties = new List<string>()
            {
                {"Hawaiian"}
            };

            CustomerList = new List<User>();
            // foreach (var i in db.Users.ToList())
            // {
            //     CustomerList.Add(new User(new Login(db.Login.ToList().ElementAt(i.LoginId).UserName, db.Login.ToList().ElementAt(i.LoginId).Password),
            //     i.Name,i.Address,
            //     i.Address2,
            //     i.ZipCode,
            //     i.City,
            //     i.State));
            // }
            OrderList = new List<Orders>();
            foreach (var i in db.Orders.ToList())
            {
                OrderList.Add(new Orders(i.CustUserName)
                {
                    Price = i.Price,
                    OrderTime = i.OrderTime
                });
            }
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
            Toppings[] toppingsList = new Toppings[Pizza.MAXTOPPINGS];

            foreach (int i in list)
            {
                toppingsList[i - 1] = StoreToppings.ElementAt(i - 1);
            }
            newOrder.AddPizzaToOrder(new Custom().Make(PizzaSizes.ElementAt(size - 1), Crust.ElementAt(crust - 1), toppingsList));
        }

        public void AddSpecialtyToOrder(ABasePizza p)
        {
            newOrder.AddPizzaToOrder(p);
        }

        public void AddCustomer(Login l, string name, string addr, string addr2, string zip, string city, string state)
        {
            User newCustomer = new User(l, name, addr, addr2, zip, city, state);
            CustomerList.Add(newCustomer);
            // db.Login.Add( new DataB.Login(){UserName = l.UserName, Password = l.Password});
            // db.Users.Add(new DataB.Users()
            // {
            //     Name = name,
            //     Address = addr,
            //     Address2 = addr2,
            //     ZipCode = zip,
            //     City = city,
            //     State = state
            // });
            //db.SaveChanges();
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
            db.Orders.Add(new DataB.Orders()
            {
                CustUserName = newOrder.UsernameOfCustomer,
                Price = newOrder.Price,
                OrderTime = newOrder.OrderTime
            });
            newOrder = new Orders(OnlineUser);
           
           db.SaveChanges();
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