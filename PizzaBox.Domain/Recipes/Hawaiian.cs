using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Recipes
{
    public class Hawaiian : ASpecialtyBlueprint
    {
        Data.Entities.PizzaBoxDB2Context db = new Data.Entities.PizzaBoxDB2Context();

        public override ABasePizza Make(Size s, Crust c)
        {
            Data.Entities.ToppingsDb[] t = new Data.Entities.ToppingsDb[] {new Data.Entities.ToppingsDb(), new Data.Entities.ToppingsDb()};
            return new Pizza(s,c,t);
        }
    }
}