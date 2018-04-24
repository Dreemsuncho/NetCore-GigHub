using System.ComponentModel.DataAnnotations;

namespace NetCore_GigHub.Controllers
{
    public class ViewModelLogin
    {
        [Required]
        [StringLength(40)]
        public string Username { get; set; }

        [Required]
        [StringLength(40)]
        public string Password { get; set; }
    }
}