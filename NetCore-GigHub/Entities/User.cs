using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NetCore_GigHub.Entities
{
    public class User : IdentityUser<int>
    {
        [Required]
        [StringLength(40)]
        public override string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(40)]
        public override string Email { get; set; }
    }
}
