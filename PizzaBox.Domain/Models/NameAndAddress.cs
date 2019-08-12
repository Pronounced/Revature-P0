namespace PizzaBox.Domain.Models
{
    public abstract class NameAndAddress
    {
        protected string Name { get; set; }
        protected string Address { get; set; }
        protected string Address2 { get; set; }
        protected string ZipCode { get; set; }
        protected string City { get; set; }
        protected string State { get; set; }
    }
}