using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class ACustomBlueprint
    {
        public abstract ABasePizza Make(Size s, Crust c, Toppings[] t);
    }
}