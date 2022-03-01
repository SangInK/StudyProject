using Microsoft.AspNetCore.Identity;

namespace MyApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string NickName { get; set; }
    }
}
