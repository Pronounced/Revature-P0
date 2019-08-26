namespace PizzaBox.Domain.Abstracts
{
    public abstract class AInventory
    {
        string Name { get; set; }
        decimal Price { get; set; }
        int Key { get; set; }

        public AInventory(string name, decimal price, int key)
        {
            Name = name;
            Price = price;
            Key = key;
        }
    }
}