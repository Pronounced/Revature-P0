using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Recipes
{
    public class Hawaiian : ASpecialtyBlueprint
    {
        public override ABasePizza Make(Size s, Crust c)
        {
            Toppings[] t = new Toppings[] {new Toppings("Ham", 1), new Toppings("Pineapple", 1)};
            return new Pizza(s,c,t);
        }
    }
}