using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Domain.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public Login(string user, string pass)
        {
            UserName = user;
            Password = pass;
        }
    }
}