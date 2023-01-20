﻿using System.ComponentModel.DataAnnotations;

namespace ECommerceWebApp.Models
{
    public class ProductCategory
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
