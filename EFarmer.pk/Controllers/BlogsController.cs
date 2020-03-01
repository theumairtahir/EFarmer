using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using EFarmer.pk.Models;
using EFarmer.pk.ViewModels.BlogsViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace EFarmer.pk.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IContainer _container;
        private readonly IStringLocalizer<HomeController> _localizer;
        public BlogsController(IStringLocalizer<HomeController> localizer)
        {
            _container = new ModelsFactory().Build();
            _localizer = localizer;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult _BlogPostPartial(int id)
        {
            BlogPostViewModel model = new BlogPostViewModel();
            if (id == 1)
            {
                model = new BlogPostViewModel
                {
                    Id=1,
                    Picture = "1.jpg",
                    PostedDateTime = new DateTime(2020, 3, 1).ToString(Common.CommonValues.BLOG_DATE_FORMAT),
                    ShortDescription = "Agriculture is one of the major contributory " +
                    "sectors in Pakistan's economy. " +
                    "This sector both directly and indirectly supports Pakistan’s populace and accounts " +
                    "for 26 percent of country’s Gross Domestic Product (GDP). " +
                    "The primary agricultural crops include cotton, wheat, rice, sugarcane, fruits & vegetables. " +
                    "With the introduction of Digital Pakistan Initiative by PM Imran Khan, how can this major sector not benefit " +
                    "from this drive in an IT driven era. We InfoTronix Pakistan have launched eFarmer.pk  " +
                    "Pakistan’s first Kisan Dost Bazaar to empower and facilitate all the people linked with " +
                    "Agricultural Sector in Pakistan, with a friendly platform where they can get the right cost for " +
                    "their efforts both Inland & Abroad. A place where Buyers & Sellers meet.",
                    Title = "About E-Farmer.pk"
                };
            }
            else if (id == 2)
            {
                model = new BlogPostViewModel
                {
                    Id=2,
                    Picture = "2.jpg",
                    PostedDateTime = new DateTime(2020, 3, 1).ToString(Common.CommonValues.BLOG_DATE_FORMAT),
                    ShortDescription = "Over 70% of Pakistan’s population is directly or indirectly dependent " +
                    "on agricultural sector. However, unfortunately till now there " +
                    "did not exist even a single ecommerce portal that explicitly targeting " +
                    "this large & crucial industry in Pakistan. We are here with a vision of " +
                    "introducing our farmers not only to the local market but very soon to the " +
                    "international market to increase Pakistan’s agricultural exports.",
                    Title = "Role of Agriculture in Pakistan's Enconomy"
                };
            }
            else if (id == 3)
            {
                model = new BlogPostViewModel
                {
                    Id=3,
                    Picture = "3.jpg",
                    PostedDateTime = new DateTime(2020, 3, 1).ToString(Common.CommonValues.BLOG_DATE_FORMAT),
                    ShortDescription = "efarmer.pk is Pakistan’s largest Agricultural Market Place where Buyers " +
                    "& Sellers meet. eFarmer.pk offers services facilitating Famers, Brokers, Market Retailers " +
                    "and Consumers to buy and sell all kinds of agricultural products & services on a single forum." +
                    "eframer.pk is launched with a vision to facilitate our farmer in during complete cycle of crop" +
                    " production starting from buying online seeds, pesticides, fertilizers and taking all agricultural machinery on rent. Once the crop is ready efarmer.pk facilitate farmer to sell " +
                    "their end product online to various buyers on best rate without any delay. eframer.pk is a virtual community of buyers and sellers  " +
                    "where famers, brokers, market retailers can sell their agricultural product including wide range of crops, fruits and vegetables. " +
                    "Moreover it also facilitates famer to buy Agro seeds, agro chemicals and fertilizer on a single app. Agricultural machinery on rent " +
                    "service is also available on efarmer.pk",
                    Title = "EFarmer.pk is The Largest Marketplace"
                };
            }
            return PartialView(model);
        }
    }
}