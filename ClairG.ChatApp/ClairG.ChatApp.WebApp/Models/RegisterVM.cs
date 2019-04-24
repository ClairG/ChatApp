using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClairG.ChatApp.WebApp.Models
{
    public class RegisterVM
    {
        [Required, MinLength(5)]
        public string Username { get; set; }

        [Required, MinLength(5), DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password"), DataType(DataType.Password)]
        [Display(Name="Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
    }
}