using System.ComponentModel.DataAnnotations;

namespace ECommerceWebApp.Models
{
    public class Product
    {
        [Required]
        public string ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string Image { get; set; }

        [Required]
        public string ProductCategoryId { get; set; }

        public ProductCategory ProductCategory { get; set; }


    }
}
