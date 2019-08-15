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
                System.Console.WriteLine();
                System.Console.WriteLine("Select An Option");
                System.Console.WriteLine("1. Create An Account");
                System.Console.WriteLine("2. Place An Order");
                System.Console.WriteLine("3. Print Inventory");
                System.Console.WriteLine("4. Print Order");
                System.Console.WriteLine("5. Pring Customers");
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
                        GetInfo();
                        break;
                    
                    case 2:
                        OrderPizza();
                        break;

                    case 3:
                        PrintInventory();
                        break;

                    case 4:
                        PrintOrders();
                        break;

                    default:
                        break;
                }
            } while (input != 7);
        }

        private void GetInfo()
        {
            string name, addr, addr2, zip, city, state;
            System.Console.WriteLine();
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
            ps.AddCustomer(name, addr, addr2, zip, city, state);
            System.Console.WriteLine();
            PrintCustomers();
            System.Console.WriteLine();
        }

        private void OrderPizza()
        {
            List<string> toppings = new List<string>();
            int size;
            string userToppings;

            System.Console.WriteLine();
            System.Console.WriteLine("Select a Pizza Size: ");
            System.Console.WriteLine("1. Small 2. Medium 3. Large");
            size = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine();

            do
            {
                int count = 0;

                System.Console.WriteLine("Select A Topping: ");
                foreach (KeyValuePair<string, double> i in ps.StoreToppings)
                {
                    count++;
                    System.Console.WriteLine(count.ToString() + "." + i.Key);
                }
                System.Console.WriteLine("-1 to finish");
                userToppings = Console.ReadLine();
                if (userToppings != "-1")
                {
                    toppings.Add(userToppings);                   
                }
                System.Console.WriteLine();
            }while(userToppings != "-1");
            ps.AddToOrder(size, toppings);
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