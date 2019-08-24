using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Recipes;
using DataB = PizzaBox.Data.Entities;

namespace PizzaBox.Client
{
    public class Menu
    {
        DataB.PizzaBoxDB2Context db = new DataB.PizzaBoxDB2Context();

        static List<Location> StoreLocations = new List<Location>();

        public Hawaiian hawaiian = new Hawaiian();

        public Location PizzaStore { get; set; }

        public void DisplayMenu()
        {
            foreach (var i in db.Location.ToList())
            {
                StoreLocations.Add(new Location(i.Name,i.Address,i.Address2,i.ZipCode,i.City,i.State));
            }

            PizzaStore = StoreLocations.ElementAt(0);

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
                    System.Console.WriteLine("\nInvalid Input\n");
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
                            System.Console.WriteLine("\nLogin Incorrect!\n");
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
                    System.Console.WriteLine("\nAll fields must have a value\n");
                }
            }while((name == "") || (addr == "") || (addr2 == "") || (zip == "") || (city == "") || (state == "") || (user == "") || (pass == ""));
            PizzaStore.AddCustomer(new Login(user,pass), name, addr, addr2, zip, city, state);
        }

        public void UserMenu()
        {
            int input;
            do
            {
                Console.WriteLine();
                System.Console.WriteLine("Select An Option");
                System.Console.WriteLine("1. Order A Custom Pizza");
                System.Console.WriteLine("2. Order A Specialty Pizza");
                System.Console.WriteLine("3. Preview Order");
                System.Console.WriteLine("4. Confirm Order");
                System.Console.WriteLine("5. Print Previous Orders");
                System.Console.WriteLine("6. Change Locations");
                System.Console.WriteLine("7. Log Out");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());

                }
                catch (FormatException)
                {
                    System.Console.WriteLine("\nInvalid Input\n");
                    input = 0;
                }

                switch (input)
                {
                    case 1:
                        OrderCustomPizza();
                        break;

                    case 2:
                        OrderSpecialtyPizza();
                        break;
                        
                    case 3:
                        PrintOrder();
                        break;

                    case 4:
                        if(!PizzaStore.CheckLastLocation())
                        {
                            System.Console.WriteLine("\nYou can only order from 1 location a day\n");
                        }
                        else if(!PizzaStore.CheckLastOrder())
                        {
                            System.Console.WriteLine("\nToo soon after last order\n");
                        }
                        else
                        {
                            ConfirmOrder();
                        }                    
                        break;

                    case 5:
                        PrintPreviousOrders();
                        break;

                    case 6:
                        ChangeLocations();
                        break;

                    default:
                        break;
                }
            } while (input != 7);
        }

        private void OrderCustomPizza()
        {
            List<int> toppings = new List<int>();
            int size, crust;
            int userToppings;
            int count = 0;

            try
            {            
                System.Console.WriteLine();
                System.Console.WriteLine("Select a Pizza Size: ");
                foreach (Size i in PizzaStore.PizzaSizes)
                {
                    count++;
                    System.Console.WriteLine(count.ToString() + "." + i.Name + " " + i.Price);
                }
                size = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine();

                count = 0;
                System.Console.WriteLine();
                System.Console.WriteLine("Select a Crust: ");
                foreach (Crust i in PizzaStore.Crust)
                {
                    count++;
                    System.Console.WriteLine(count.ToString() + "." + i.Name + " " + i.Price);
                }
                crust = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine();

                do
                {
                    count = 0;
                    System.Console.WriteLine("Select A Topping (Minimum of " + Pizza.MINTOPPINGS + ", Max of " + Pizza.MAXTOPPINGS + "): ");
                    foreach (Toppings i in PizzaStore.StoreToppings)
                    {
                        count++;
                        System.Console.WriteLine(count.ToString() + "." + i.Name + " " + i.Price);
                    }
                    userToppings = Int32.Parse(Console.ReadLine());
                    toppings.Add(userToppings);                   
                    System.Console.WriteLine();
                }while(toppings.Count < Pizza.MINTOPPINGS);
                do
                {
                    count = 0;
                    System.Console.WriteLine("Select A Topping (Minimum of " + Pizza.MINTOPPINGS + ", Max of " + Pizza.MAXTOPPINGS + "): ");
                    foreach (Toppings i in PizzaStore.StoreToppings)
                    {
                        count++;
                        System.Console.WriteLine(count.ToString() + "." + i.Name + " " + i.Price);
                    }
                    System.Console.WriteLine("-1 to finish");
                    userToppings = Int32.Parse(Console.ReadLine());
                    if (userToppings != -1 && toppings.Count < Pizza.MAXTOPPINGS)
                    {
                        toppings.Add(userToppings);                   
                    }
                    System.Console.WriteLine();
                }while(userToppings != -1 && toppings.Count < Pizza.MAXTOPPINGS);
                PizzaStore.AddCustomToOrder(size, crust, toppings);
            }
            catch (FormatException)
            {
                System.Console.WriteLine("\nInvalid Input\n");
            }
        }

        private void OrderSpecialtyPizza()
        {
            int size, crust, specialty;
            int count = 0;

            try
            {
                Console.WriteLine();
                System.Console.WriteLine("Select A Specialty Pizza: ");
                foreach (string i in PizzaStore.Specialties)
                {
                    count++;
                    System.Console.WriteLine(count.ToString() + "." + i);
                }            
                specialty = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine();

                count = 0;
                System.Console.WriteLine();
                System.Console.WriteLine("Select a Pizza Size: ");
                foreach (Size i in PizzaStore.PizzaSizes)
                {
                    count++;
                    System.Console.WriteLine(count.ToString() + "." + i.Name + " " + i.Price);
                }
                size = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine();

                count = 0;
                System.Console.WriteLine();
                System.Console.WriteLine("Select a Crust: ");
                foreach (Crust i in PizzaStore.Crust)
                {
                    count++;
                    System.Console.WriteLine(count.ToString() + "." + i.Name + " " + i.Price);
                }
                crust = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine();
                switch(specialty)
                {
                    case 1:
                        PizzaStore.AddSpecialtyToOrder(hawaiian.Make(PizzaStore.PizzaSizes.ElementAt(size - 1), PizzaStore.Crust.ElementAt(crust - 1)));
                        break;

                    default:
                        break;
                }
            }
            catch (FormatException)
            {
                System.Console.WriteLine("\nInvalid Input\n");
            }
        }

        public bool Login()
        {
            string user, pass;
            System.Console.WriteLine();
            System.Console.WriteLine("Username: ");
            user = Console.ReadLine();
            System.Console.WriteLine("Password: ");
            pass = Console.ReadLine();
            Location.OnlineUser = user;
            return PizzaStore.LoginCheck(user,pass);
        }

        public void PrintCustomers()
        {
            System.Console.WriteLine();
            Location.CustomerList.ForEach(Console.WriteLine);
        }

        public void PrintOrder()
        {
            System.Console.WriteLine();
            System.Console.WriteLine(PizzaStore.newOrder);
        }

        public void PrintInventory()
        {
            System.Console.WriteLine();
            foreach (KeyValuePair<string, int> item in PizzaStore.Inventory)
            {
                Console.WriteLine($"Ingredient: {item.Key}, Stock: {item.Value}");
            }
        }

        public void PrintPreviousOrders()
        {
            System.Console.WriteLine();
            foreach (Orders i in PizzaStore.OrderList)
            {
                if(Location.OnlineUser == i.UsernameOfCustomer)
                {
                    System.Console.WriteLine(i);
                }
            }
        }

        public void ChangeLocations()
        {
            int count = 0;
            System.Console.WriteLine("\nSelect A Location: ");
            foreach (var i in StoreLocations)
            {
                count++;
                System.Console.WriteLine(count.ToString() + "." + i);
            }
            try
            {
                PizzaStore = StoreLocations.ElementAt(Int32.Parse(Console.ReadLine()) - 1);
            }
            catch (FormatException)
            {
                System.Console.WriteLine("\nInvalid Input\n");
            }
            System.Console.WriteLine($"New Location is {PizzaStore}");
        }

        public void ConfirmOrder()
        {
            PizzaStore.AddOrderToList();
        }
    }
}