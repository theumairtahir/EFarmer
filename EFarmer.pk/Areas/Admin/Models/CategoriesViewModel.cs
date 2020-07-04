using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFarmer.pk.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
    public class CategoriesListingViewModel
    {
        public int Id { get; set; }
        public string ActionButtons { get; set; }
        public string Name { get; set; }
    }
}
