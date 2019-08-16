namespace PizzaBox.Domain.Interfaces
{
    public interface INameAndAddress
    {
        string Name { get; set; }
        string Address { get; set; }
        string Address2 { get; set; }
        string ZipCode { get; set; }
        string City { get; set; }
        string State { get; set; }
    }
}