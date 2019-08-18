using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        private IDictionary<string, string> userLogin = new Dictionary<string, string>();
        public IDictionary<string, string> UserLogin { get => userLogin; set => userLogin = value; }

    }
}