using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceWebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Your first name is required.")]
        [Column(TypeName = "text")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Your last name is required.")]
        [Column(TypeName = "text")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "A valid email address is required.")]
        [StringLength(80)]
        [EmailAddress(ErrorMessage = "This email address is invalid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A valid password is required.")]
        [Column(TypeName = "text")]
        [MinLengthAttribute(8, ErrorMessage = "Password requires a minimum of 8 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "A valid password is required.")]
        [Column(TypeName = "text")]
        [MinLengthAttribute(8, ErrorMessage = "Password requires a minimum of 8 characters.")]
        public string ConfirmPassword { get; set; }
    }
}
