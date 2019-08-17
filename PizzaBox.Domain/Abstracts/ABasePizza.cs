using System;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class ABasePizza
    {
        public static readonly int MINTOPPINGS = 2;
        public static readonly int MAXTOPPINGS = 5;
        public Size PizzaSize { get; set; }
        public Crust PizzaCrust { get; set; }

        private Toppings[] userToppings = new Toppings[MAXTOPPINGS];

        public Toppings[] UserToppings
        {
            get
            {
                return userToppings;
            }

            protected set
            {
                userToppings = value;
            }
        }

        public abstract decimal calculatePizzaPrice();

    }
}