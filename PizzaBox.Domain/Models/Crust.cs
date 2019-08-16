using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Crust : IInventory
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Crust(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}