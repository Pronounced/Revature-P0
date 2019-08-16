using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Size : IInventory
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Size(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}