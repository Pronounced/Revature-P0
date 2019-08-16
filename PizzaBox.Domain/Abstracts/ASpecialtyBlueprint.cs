using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class ASpecialtyBlueprint
    {
        public abstract ABasePizza Make(Size s, Crust c);
    }
}