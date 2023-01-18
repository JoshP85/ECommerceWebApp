using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceWebApp.Models
{
    public class Auth
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "A valid password is required.")]
        [Column(TypeName = "text")]
        [MinLengthAttribute(8, ErrorMessage = "Password requires a minimum of 8 characters.")]
        public string Password { get; set; }
    }
}
