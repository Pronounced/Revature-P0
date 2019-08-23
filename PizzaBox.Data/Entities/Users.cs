using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Users
    {
        public int UsersId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int LoginId { get; set; }

        public virtual Login Login { get; set; }
    }
}
