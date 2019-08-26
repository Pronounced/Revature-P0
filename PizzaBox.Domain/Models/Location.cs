using System;
using System.Collections.Generic;
using System.Linq;
using DataB = PizzaBox.Data.Entities;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Recipes;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Domain.Models
{
    public class Location : ANameAndAddress
    {
        public static string OnlineUser { get; set; }

        public static List<User> CustomerList { get; protected set; }

        public List<Order> OrderList { get; protected set; }

        public IDictionary<string, int> Inventory { get; protected set; }

        public List<Toppings> StoreToppings { get; set; }

        public List<Size> PizzaSizes { get; set; }

        public List<Crust> Crust { get; set; }

        public List<string> Specialties { get; set; }

        //Custom CustomPizza;

        public Order newOrder;

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
                StoreToppings.Add(new Toppings(i.Name,i.Price,i.ToppingsId));
            }

            PizzaSizes = new List<Size>();
            foreach (var i in db.Size.ToList())
            {
                PizzaSizes.Add(new Size(i.Name, i.Price, i.SizeId));
            }

            Crust = new List<Crust>();
            foreach (var i in db.Crust.ToList())
            {
                Crust.Add(new Crust(i.Name, i.Price, i.CrustId));
            }

            Specialties = new List<string>()
            {
                {"Hawaiian"}
            };

            CustomerList = new List<User>();
            foreach (var i in db.Users.Include(i => i.Login).ToList())
            {
                CustomerList.Add
                (
                    new User
                    (
                        new Login(i.Login.UserName, i.Login.Password),
                        i.Name,
                        i.Address,
                        i.Address2,
                        i.ZipCode,
                        i.City,
                        i.State
                    )
                );
            }

            OrderList = new List<Order>();
            foreach (var i in db.Orders.ToList())
            {
                OrderList.Add(new Order(i.CustUserName)
                {
                    Price = i.Price,
                    OrderTime = i.OrderTime,
                    OrderId = i.OrdersId
                });
            }

            Inventory = new Dictionary<string, int>();
            newOrder = new Order(OnlineUser);

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
            var loginKey = new DataB.Login(){UserName = l.UserName, Password = l.Password};
            db.Login.Add(loginKey);
            db.Users.Add(new DataB.Users()
            {
                Name = name,
                Address = addr,
                Address2 = addr2,
                ZipCode = zip,
                City = city,
                State = state,
                LoginId =  loginKey.LoginId
                
            });
            db.SaveChanges();
        }

        public bool LoginCheck(string user, string pass)
        {
            foreach (var i in CustomerList)
            {
                if((user == i.UserLogin.UserName) && (pass == i.UserLogin.Password))
                {
                    newOrder = new Order(user);
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
            var dbOrders = new DataB.Orders()
            {
                CustUserName = newOrder.UsernameOfCustomer,
                Price = newOrder.Price,
                OrderTime = newOrder.OrderTime
            };
            db.Orders.Add(dbOrders);

            foreach (var i in newOrder.Pizzas)
            {
                db.Pizza.Add(new DataB.Pizza()
                {
                    CrustId = i.PizzaCrust.CrustKey,
                    SizeId = i.PizzaSize.SizeKey,
                    Price = i.calculatePizzaPrice(),
                    OrdersId = dbOrders.OrdersId
                });
            }
            db.SaveChanges();

            newOrder = new Order(OnlineUser);
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