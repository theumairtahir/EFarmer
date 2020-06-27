using System.Collections.Generic;

namespace EFarmer.pk.Areas.Admin.Models.Shared
{
    public class BreadcrumbViewModel
    {
        public BreadcrumbViewModel()
        {
            BreadCrumbs = new List<BreadCrumb>();
        }
        public List<BreadCrumb> BreadCrumbs { get; set; }
    }
    public class BreadCrumb
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public bool IsLast { get; set; }
    }
}
