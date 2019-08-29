using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Recipes
{
    public class Hawaiian : ASpecialtyBlueprint
    {
        Data.Entities.PizzaBoxDB2Context db = new Data.Entities.PizzaBoxDB2Context();

        public override ABasePizza Make(Size s, Crust c)
        {
            Toppings[] t = new Toppings[] {new Toppings("Ham", 1, 0), new Toppings("Pineapple", 1, 0)};
            foreach (var i in db.ToppingsDb.ToList())
            {
                foreach (var x in t)
                {
                    if(i.Name == x.Name)
                    {
                        x.ToppingsKey = i.ToppingsId;
                    }
                }
            }
            return new Pizza(s,c,t);
        }
    }
}