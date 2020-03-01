using System.ComponentModel.DataAnnotations;

namespace EFarmer.pk.ViewModels.AccountViewModels
{
    public class RegisterAccountViewModel
    {
        [Required]
        [Display(Name="Full Name", Description ="Enter your full name")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Contact Number")]
        [Phone]
        public string ContactNumber { get; set; }
        [Display(Name ="Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class LoginAccountViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool IsRemembered { get; set; }
    }
    public class ForgetAccountViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}