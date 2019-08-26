using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Crust : AInventory
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CrustKey { get; set; }

        public Crust(string name, decimal price, int key) : base(name, price, key)
        {
            Name = name;
            Price = price;
            CrustKey = key;
        }
    }
}