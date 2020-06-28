using EFarmer.pk.Areas.Admin.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFarmer.pk.Areas.Admin.Common
{
    public static class Functions
    {
        public static BreadcrumbViewModel CreateBreadCrumb(params BreadCrumb[] breadCrumb)
        {
            if (breadCrumb is null)
            {
                return new BreadcrumbViewModel();
            }
            var breadCrumbsViewModel = new BreadcrumbViewModel
            {
                BreadCrumbs = breadCrumb.ToList()
            };
            return breadCrumbsViewModel;
        }
    }
}
