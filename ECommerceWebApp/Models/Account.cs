﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceWebApp.Models
{
    public class Account
    {
        public Account()
        {
            Id = "test";//Guid.NewGuid().ToString();
            Type = AccountType.Customer;
        }

        public enum AccountType
        {
            Customer,
            Employee,
            Admin
        }

        [Key]
        public string Id { get; set; }
        public AccountType Type { get; set; }

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

        [StringLength(20)]
        [Column(TypeName = "text")]
        public string Phone { get; set; }
        public string Address { get; set; }

    }
}
