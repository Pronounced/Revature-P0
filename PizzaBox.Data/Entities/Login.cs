using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Login
    {
        public Login()
        {
            Users = new HashSet<Users>();
        }

        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
