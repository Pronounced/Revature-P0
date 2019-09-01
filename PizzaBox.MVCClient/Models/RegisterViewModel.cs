using PizzaBox.Domain.Models;

namespace PizzaBox.MVCClient.Models
{
    public class RegisterViewModel
    {
        string user = "", pass = "", name = "", addr1 = "", addr2 = "", zip = "", city = "", state = "";
        public Login Login { get; set; }
        public User User { get; set; }

        public RegisterViewModel()
        {
            Login = new Login(user, pass);
            User = new User(Login, name, addr1, addr2, zip, city, state);
        }
    }
}