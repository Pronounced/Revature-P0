using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            int input;

            do
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Select An Option");
                System.Console.WriteLine("1. Create An Account");
                System.Console.WriteLine("2. Place An Order");
                System.Console.WriteLine("Enter '-1'  to exit.");
                input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        GetInfo();
                        break;
                    
                    case 2:
                        OrderPizza();
                        break;

                    default:
                        break;
                }
            } while (input != -1);
        }

        static void GetInfo()
        {
            Location ps = new Location(
                "Pizza Place",
                "101 Pizza St",
                "Suite 1",
                "77777",
                "FlavorTown",
                "Texas");

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
            ps.PrintCustomers();
            System.Console.WriteLine();
        }

        static void OrderPizza()
        {
            Location ps = new Location(
                "Pizza Place",
                "101 Pizza St",
                "Suite 1",
                "77777",
                "FlavorTown",
                "Texas");

            List<string> toppings = new List<string>();
            int size;

            System.Console.WriteLine();
            System.Console.WriteLine("Select a Pizza Size: ");
            System.Console.WriteLine("1. Small 2. Medium 3. Large");
            size = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine();
            System.Console.WriteLine("Enter Toppings: (seperate with a space)");
            toppings.Add(Console.ReadLine());
            System.Console.WriteLine();
            ps.AddToOrder(size, toppings);
            ps.PrintPizza();
        }
    }
}
