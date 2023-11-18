using System.ComponentModel.DataAnnotations;

namespace WebblogWebDB2.DTOs
{
    public class Regester
    {
        public string  FistName { get; set; }
        public string  LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password  { get; set; }
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }
    }
}
