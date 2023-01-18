using System.ComponentModel.DataAnnotations;

namespace ECommerceWebApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "A valid email address is required.")]
        [StringLength(80)]
        [EmailAddress(ErrorMessage = "This email address is invalid.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
