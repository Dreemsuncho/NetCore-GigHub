using Microsoft.AspNetCore.Identity;

namespace NetCore_GigHub.Entities
{
    public class User : IdentityUser<int>
    {
        public override string UserName { get; set; }
        public override string Email { get; set; }
    }
}
