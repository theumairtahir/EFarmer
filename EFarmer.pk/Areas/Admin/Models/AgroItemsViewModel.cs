using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFarmer.pk.Areas.Admin.Models
{
    public class AgroItemViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Item Name")]
        public string Name { get; set; }
        [Display(Name = "Weight Scale")]
        public string WeightScale { get; set; }
        [Display(Name = "Category")]
        public int Category { get; set; }
    }
    public class AgroItemListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WeightScale { get; set; }
        public string Category { get; set; }
        public string ActionButtons { get; set; }
    }
}
