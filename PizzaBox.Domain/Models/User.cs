namespace PizzaBox.Domain.Models
{
    public class User : NameAndAddress
    {
        public User(string name, string addr, string addr2, string zip, string city, string state)
        {
            Name = name;
            Address = addr;
            Address2 = addr2;
            ZipCode = zip;
            City = city;
            State = state;
        }
    }
}