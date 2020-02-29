using System.ComponentModel.DataAnnotations;

namespace EFarmer.pk.ViewModels.AccountViewModels
{
    public class RegisterAccountViewModel
    {
        [Required]
        [Display(Name="Full Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Contact Number")]
        public string ContactNumber { get; set; }
        [Required]
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}