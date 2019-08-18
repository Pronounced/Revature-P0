using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
    public class Menu
    {
        public Location ps = new Location(
                "Pizza Place",
                "101 Pizza St",
                "Suite 1",
                "77777",
                "FlavorTown",
                "Texas");

        public void DisplayMenu()
        {
            int input;

            do
            {
                System.Console.WriteLine("Select An Option");
                System.Console.WriteLine("1. Create An Account");
                System.Console.WriteLine("2. Login");
                System.Console.WriteLine("3. Quit");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());

                }
                catch (FormatException)
                {
                    System.Console.WriteLine("Invalid Input");
                    input = 0;
                }

                switch (input)
                {
                    case 1:
                        GetInfo();
                        break;

                    case 2:
                        if(Login() == true)
                        {
                            UserMenu();
                        }
                        else
                        {
                            System.Console.WriteLine("Login Incorrect!");
                            System.Console.WriteLine();
                        }
                        break;

                    default:
                        break;
                }            
            }while(input != 3);
        }

        private void GetInfo()
        {
            string user, pass, name, addr, addr2, zip, city, state;
            do
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Enter a User Name: ");
                user = Console.ReadLine();
                System.Console.WriteLine("Enter a Password: ");
                pass = Console.ReadLine();
                System.Console.WriteLine("Enter Name: ");
                name = Console.ReadLine();
                System.Console.WriteLine("Enter Address: ");
                addr = Console.ReadLine();
                System.Console.WriteLine("Enter Address 2: ");
                addr2 = Console.ReadLine();
                System.Console.WriteLine("Enter Zip Code: ");
                zip = Console.ReadLine();
                System.Console.WriteLine("Enter City: ");
                city = Console.ReadLine();
                System.Console.WriteLine("Enter State: ");
                state = Console.ReadLine();
                if((name == "") || (addr == "") || (addr2 == "") || (zip == "") || (city == "") || (state == "") || (user == "") || (pass == ""))
                {
                    System.Console.WriteLine("All fields must have a value");
                }
            }while((name == "") || (addr == "") || (addr2 == "") || (zip == "") || (city == "") || (state == "") || (user == "") || (pass == ""));
            ps.AddCustomer(user, pass, name, addr, addr2, zip, city, state);
        }

        private void OrderPizza()
        {
            List<string> toppings = new List<string>();
            int size, crust;
            string userToppings;
            int count = 0;

            System.Console.WriteLine();
            System.Console.WriteLine("Select a Pizza Size: ");
            foreach (Size i in ps.PizzaSizes)
            {
                count++;
                System.Console.WriteLine(count.ToString() + "." + i.Name);
            }
            size = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine();

            count = 0;
            System.Console.WriteLine();
            System.Console.WriteLine("Select a Crust: ");
            foreach (Crust i in ps.Crust)
            {
                count++;
                System.Console.WriteLine(count.ToString() + "." + i.Name);
            }
            crust = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine();

            do
            {
                count = 0;
                System.Console.WriteLine("Select A Topping (Minimum of " + Pizza.MINTOPPINGS + ", Max of " + Pizza.MAXTOPPINGS + "): ");
                foreach (Toppings i in ps.StoreToppings)
                {
                    count++;
                    System.Console.WriteLine(count.ToString() + ". " + i.Name);
                }
                System.Console.WriteLine("-1 to finish");
                userToppings = Console.ReadLine();
                if (userToppings != "-1" && toppings.Count < Pizza.MAXTOPPINGS)
                {
                    toppings.Add(userToppings);                   
                }
                System.Console.WriteLine();
            }while(userToppings != "-1");
            ps.AddCustomToOrder(size, crust, toppings);
        }


        public void UserMenu()
        {
            int input;
            do
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Select An Option");
                System.Console.WriteLine("1. Place An Order");
                System.Console.WriteLine("2. Print Inventory");
                System.Console.WriteLine("3. Print Order");
                System.Console.WriteLine("4. Print Customers");
                System.Console.WriteLine("7. Quit");
                
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());

                }
                catch (FormatException)
                {
                    System.Console.WriteLine("Invalid Input");
                    input = 0;
                }

                switch (input)
                {
                    case 1:
                        OrderPizza();
                        break;

                    case 2:
                        PrintInventory();
                        break;

                    case 3:
                        PrintOrders();
                        break;

                    case 4:
                        PrintCustomers();
                        break;

                    default:
                        break;
                }
            } while (input != 7);            
        }

        public bool Login()
        {
            string user, pass;
            System.Console.WriteLine();
            System.Console.WriteLine("Username: ");
            user = Console.ReadLine();
            System.Console.WriteLine("Password: ");
            pass = Console.ReadLine();
            return ps.LoginCheck(user,pass);
        }

        public void PrintCustomers()
        {
            System.Console.WriteLine();
            ps.CustomerList.ForEach(Console.WriteLine);
        }

        public void PrintOrders()
        {
            System.Console.WriteLine();
            ps.OrderList.ForEach(Console.WriteLine);
        }

        public void PrintInventory()
        {
            System.Console.WriteLine();
            foreach (KeyValuePair<string, int> item in ps.Inventory)
            {
                Console.WriteLine($"Ingredient: {item.Key}, Stock: {item.Value}");
            }
        }
    }
}