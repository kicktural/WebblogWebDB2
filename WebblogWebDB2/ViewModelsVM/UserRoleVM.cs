using WebblogWebDB2.Models;

namespace WebblogWebDB2.ViewModelsVM
{
    public class UserRoleVM
    {
        public User User { get; set; }
        public List<string> Roles { get; set; }
    }
}
