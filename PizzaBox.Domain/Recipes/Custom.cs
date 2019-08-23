using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Recipes
{
    public class Custom : ACustomBlueprint
    {
        public override ABasePizza Make(Size s, Crust c, Data.Entities.ToppingsDb[] t)
        {
            return new Pizza(s,c,t);
        }
    }
}