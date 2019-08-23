using System;
using PizzaBox.Domain.Abstracts;
namespace PizzaBox.Domain.Models
{
    public class User : ANameAndAddress
    {
        public DateTime LastOrder { get; set; }
        public Login UserLogin { get; set; }
        public Location UserLocation { get; set; }

        public User(Login l, string name, string addr, string addr2, string zip, string city, string state)
        {
            UserLogin = l;
            Name = name;
            Address = addr;
            Address2 = addr2;
            ZipCode = zip;
            City = city;
            State = state;
        }

        public override string ToString()
        {
            return $"USER: \nName: {Name} \nAddress: {Address} \nAddress 2: {Address2} \nZip: {ZipCode} \nCity: {City} \nState: {State}";
        }
    }
}