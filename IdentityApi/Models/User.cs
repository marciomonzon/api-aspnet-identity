using Microsoft.AspNetCore.Identity;

namespace IdentityApi.Models
{
    public class User : IdentityUser
    {
        public string Document { get; set; } = string.Empty;
    }
}
