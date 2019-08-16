using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Toppings : AInventory
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Toppings(string name, decimal price) : base(name, price)
        {
            Name = name;
            Price = price;
        }
    }
}