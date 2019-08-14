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
            ConsoleKeyInfo cki;

            do
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Select An Option");
                System.Console.WriteLine("1. Create An Account");
                System.Console.WriteLine("2. Place An Order");
                System.Console.WriteLine("3. Print Inventory");
                System.Console.WriteLine("Press Escape  to exit.");
                cki = Console.ReadKey(false);
                switch (cki.KeyChar.ToString())
                {
                    case "1":
                        GetInfo();
                        break;
                    
                    case "2":
                        OrderPizza();
                        break;

                    case "3":
                        PrintInventory();
                        break;

                    default:
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape);
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
            ps.PrintCustomers();
            System.Console.WriteLine();
        }

        private void OrderPizza()
        {
            List<string> toppings = new List<string>();
            int size;
            ConsoleKeyInfo cki;

            System.Console.WriteLine();
            System.Console.WriteLine("Select a Pizza Size: ");
            System.Console.WriteLine("1. Small 2. Medium 3. Large");
            size = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine();

            do
            {
                System.Console.WriteLine("Select A Topping: ");
                System.Console.WriteLine("1. Pepperoni");
                System.Console.WriteLine("2. Mushroom");
                System.Console.WriteLine("3. Sausage");
                System.Console.WriteLine("4. Olives");
                System.Console.WriteLine("5. Pineapple");
                toppings.Add(Console.ReadLine());
                System.Console.WriteLine();
                cki = Console.ReadKey(false);
            }while(cki.Key != ConsoleKey.Escape);
            ps.AddToOrder(size, toppings);
        }

        private void PrintInventory()
        {
            System.Console.WriteLine();
            ps.PrintOrders();
        }
    }
}