using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Toppings : AInventory
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ToppingsKey { get; set; }

        public Toppings(string name, decimal price, int key) : base(name, price, key)
        {
            Name = name;
            Price = price;
            ToppingsKey = key;
        }
    }
}