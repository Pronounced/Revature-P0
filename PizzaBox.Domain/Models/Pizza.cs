using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Pizza : ABasePizza
    {
         public Pizza(Size size, Crust crust, Toppings[] toppings)
        {
            PizzaSize = size;
            UserToppings = toppings;
            PizzaCrust = crust;
        }

        public override decimal calculatePizzaPrice()
        {
            decimal toppingsPrice = 0;
            for(int i = 0; i < UserToppings.Length; i++)
            {
                if(UserToppings.GetValue(i) != null)
                {
                    toppingsPrice = toppingsPrice + UserToppings[i].Price;
                }
            }
            
            return (PizzaSize.Price + toppingsPrice);
        }

        public override string ToString()
        {
            string[] pizzaToppings = new string[MAXTOPPINGS];

            for(int i = 0; i < UserToppings.Length; i++)
            {
                if(UserToppings.GetValue(i) != null)
                {
                    pizzaToppings[i] = UserToppings[i].Name;
                }
            }

            return $"\nPrice: {calculatePizzaPrice().ToString("C")}\nSize: {PizzaSize.Name} \nCrust: {PizzaCrust.Name}  \nToppings: {String.Join(" ", pizzaToppings)}";
        }
    }
}