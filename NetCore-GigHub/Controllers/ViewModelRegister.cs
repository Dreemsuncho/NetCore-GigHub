using System.ComponentModel.DataAnnotations;

namespace NetCore_GigHub.Controllers
{
    public class ViewModelRegister
    {
        [Required]
        [EmailAddress]
        [StringLength(40)]
        public string Email { get; set; }

        [Required]
        [StringLength(40)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string PasswordRepeat { get; set; }
    }
}
