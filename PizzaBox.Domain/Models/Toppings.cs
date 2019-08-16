using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Toppings : IInventory
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Toppings(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}