using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFarmer.pk.Areas.Admin.Models
{
    public class CitiesListingViewModel
    {
        public int Id { get; set; }
        public string ActionButtons { get; set; }
        public string Name { get; set; }
    }
    public class CityViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "City Name")]
        [StringLength(50, ErrorMessage = "The City Name must be less than 50 characters")]
        public string Name { get; set; }
    }
}
