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

        public Data.Entities.ToppingsDb[] UserToppings{ get; set; }

        public ABasePizza()
        {
            UserToppings = new Data.Entities.ToppingsDb[MAXTOPPINGS];
        }

        public abstract decimal calculatePizzaPrice();

    }
}