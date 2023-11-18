using System.ComponentModel.DataAnnotations;

namespace WebblogWebDB2.DTOs
{
    public class Login
    {
         
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Rememberme { get; set; }
    }
}
