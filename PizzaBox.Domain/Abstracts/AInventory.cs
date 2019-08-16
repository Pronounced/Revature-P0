namespace PizzaBox.Domain.Abstracts
{
    public abstract class AInventory
    {
        string Name { get; set; }
        decimal Price { get; set; }

        public AInventory(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}