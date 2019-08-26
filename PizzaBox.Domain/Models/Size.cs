using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Size : AInventory
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int SizeKey { get; set; }

        public Size(string name, decimal price, int key) : base(name, price, key)
        {
            Name = name;
            Price = price;
            SizeKey = key;
        }
    }
}