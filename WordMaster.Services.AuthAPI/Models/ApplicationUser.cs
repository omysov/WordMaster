using Microsoft.AspNetCore.Identity;

namespace WordMaster.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
