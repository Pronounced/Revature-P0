using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Recipes;

namespace PizzaBox.Domain.Models
{
    public class Location : ANameAndAddress
    {
        private string onlineUser;
        public string OnlineUser { get => onlineUser; set => onlineUser = value; }

        private List<User> customerList = new List<User>();
        public List<User> CustomerList { get => customerList; protected set => customerList = value; }

        private List<Orders> orderList = new List<Orders>();
        public List<Orders> OrderList { get => orderList; protected set => orderList = value; }

        IDictionary<string, int> inventory = new Dictionary<string, int>();
        public IDictionary<string, int> Inventory { get => inventory; protected set => inventory = value; }

        private List<Toppings> storeToppings = new List<Toppings>()
        {
            {new Toppings("Pepperoni", 1)},
            {new Toppings("Sausage", 1)},
            {new Toppings("Mushroom", 1)},
            {new Toppings("Olive", 1)},
            {new Toppings("Ham", 1)},
            {new Toppings("Pineapple", 1)}
        };
        public List<Toppings> StoreToppings { get => storeToppings; set => storeToppings = value; }

        public List<Size> PizzaSizes { get => pizzaSizes; set => pizzaSizes = value; }        
        private List<Size> pizzaSizes = new List<Size>()
        {
            {new Size("Small", 5)},
            {new Size("Medium", 7)},
            {new Size("Large", 9)}
        };

        public List<Crust> Crust { get => crust; set => crust = value; }
        private List<Crust> crust = new List<Crust>()
        {
            {new Crust("NY", 0)},
            {new Crust("Chicago", 0)},
            {new Crust("Traditional", 0)}
        };

        public List<string> Specialties { get => specialties; set => specialties = value; }
        private List<string> specialties = new List<string>()
        {
            {"Hawaiian"}
        };

        private IDictionary<string, string> userLogin = new Dictionary<string, string>();
        public IDictionary<string, string> UserLogin { get => userLogin; set => userLogin = value; }

        Custom CustomPizza = new Custom();
        Login login = new Login();

        public Orders newOrder;

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
            Inventory.Add("Pineapple", 50);
            Inventory.Add("Olive", 50);
            Inventory.Add("Dough", 50);
        }

        public void AddCustomToOrder(int size, int crust, List<string> list)
        {
            Toppings[] toppingsList = new Toppings[Pizza.MAXTOPPINGS];

            foreach (string i in list)
            {
                toppingsList[Int32.Parse(i) - 1] = StoreToppings.ElementAt(Int32.Parse(i) - 1);
            }
            newOrder.AddPizzaToOrder(CustomPizza.Make(PizzaSizes.ElementAt(size - 1), Crust.ElementAt(crust - 1), toppingsList));
        }

        public void AddSpecialtyToOrder(ABasePizza p)
        {
            newOrder.AddPizzaToOrder(p);
        }

        public void AddCustomer(string user, string pass, string name, string addr, string addr2, string zip, string city, string state)
        {
            User newCustomer = new User(user, pass, name, addr, addr2, zip, city, state);
            CustomerList.Add(newCustomer);
            UserLogin.Add(user,pass);
        }

        public bool LoginCheck(string user, string pass)
        {
            foreach (KeyValuePair<string,string> i in UserLogin)
            {
                if((user == i.Key) && (pass == i.Value))
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
            OrderList.Add(newOrder);
        }
    }
}