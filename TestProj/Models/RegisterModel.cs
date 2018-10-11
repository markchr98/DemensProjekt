using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProj.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Angiv venligst e-mail")]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Angiv venligst brugernavn")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Angiv venligst adgangskode")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Adgangskode skal være identisk")]
        [Display(Name = "Bekræft Adgangskode")]
        public string ConfirmPassword { get; set; }
    }
}
