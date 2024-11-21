using Microsoft.AspNetCore.Identity;

namespace MagicVill_VillAPI.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string Name { get; set; }
    }
}
