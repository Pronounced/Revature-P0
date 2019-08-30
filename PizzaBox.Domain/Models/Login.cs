using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Domain.Models
{
    public class Login
    {
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }

        public Login(string user, string pass)
        {
            UserName = user;
            Password = pass;
        }
    }
}