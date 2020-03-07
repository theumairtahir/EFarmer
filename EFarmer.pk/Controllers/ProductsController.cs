using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFarmer.pk.ViewModels.HomeViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EFarmer.pk.Controllers
{
    public class ProductsController : Controller
    {
        [Route("/Products/Crops")]
        public IActionResult ViewCrops()
        {
            return View();
        }
        public IActionResult GetCrops()
        {
            var imagePath = Common.CommonValues.CROP_DEFAULT_PIC;
            List<AdViewModel> ads = new List<AdViewModel>();
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            return PartialView("_AdsListingPartial", ads);
        }
        public IActionResult LoadCrops(int count, int lastIndex)
        {
            var imagePath = Common.CommonValues.CROP_DEFAULT_PIC;
            List<AdViewModel> ads = new List<AdViewModel>();
            for (int i = 1; i <= count; i++)
            {
                ads.Add(new AdViewModel
                {
                    Category = "Crops",
                    Id = 1,
                    CategoryId = 1,
                    Location = "Lahore",
                    Picture = imagePath,
                    Price = "Rs. 10000",
                    Rating = 4,
                    Span = "15 mins ago",
                    Title = "Lorem Ipsum"
                });
            }
            return PartialView("_AdsListingPartial", ads);
        }
        [Route("/Products/Fruits")]
        public IActionResult ViewFruits()
        {
            return View();
        }
        public IActionResult GetFruits()
        {
            var imagePath = Common.CommonValues.FRUIT_DEFAULT_PIC;
            List<AdViewModel> ads = new List<AdViewModel>();
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            return PartialView("_AdsListingPartial", ads);
        }
        public IActionResult LoadFruits(int count, int lastIndex)
        {
            var imagePath = Common.CommonValues.FRUIT_DEFAULT_PIC;
            List<AdViewModel> ads = new List<AdViewModel>();
            for (int i = 1; i <= count; i++)
            {
                ads.Add(new AdViewModel
                {
                    Category = "Crops",
                    Id = 1,
                    CategoryId = 1,
                    Location = "Lahore",
                    Picture = imagePath,
                    Price = "Rs. 10000",
                    Rating = 4,
                    Span = "15 mins ago",
                    Title = "Lorem Ipsum"
                });
            }
            return PartialView("_AdsListingPartial", ads);
        }
        [Route("/Products/Vegetabes")]
        public IActionResult ViewVegetables()
        {
            return View();
        }
        public IActionResult GetVegetables()
        {
            var imagePath = Common.CommonValues.VEG_DEFAULT_PIC;
            List<AdViewModel> ads = new List<AdViewModel>();
            ads.Add(new AdViewModel
            {
                Category = "Vegetables",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Vegetables",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Vegetables",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Vegetables",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Vegetables",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            return PartialView("_AdsListingPartial", ads);
        }
        public IActionResult LoadVegetables(int count, int lastIndex)
        {
            var imagePath = Common.CommonValues.VEG_DEFAULT_PIC;
            List<AdViewModel> ads = new List<AdViewModel>();
            for (int i = 1; i <= count; i++)
            {
                ads.Add(new AdViewModel
                {
                    Category = "Vegetables",
                    Id = 1,
                    CategoryId = 1,
                    Location = "Lahore",
                    Picture = imagePath,
                    Price = "Rs. 10000",
                    Rating = 4,
                    Span = "15 mins ago",
                    Title = "Lorem Ipsum"
                });
            }
            return PartialView("_AdsListingPartial", ads);
        }
        [Route("/Product/Pesticides")]
        public IActionResult ViewPesticides() => View();
        public IActionResult GetPesticides()
        {
            var imagePath = Common.CommonValues.PEST_DEFAULT_PIC;
            List<AdViewModel> ads = new List<AdViewModel>();
            ads.Add(new AdViewModel
            {
                Category = "Pesticides",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Pesticides",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Pesticides",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Pesticides",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Pesticides",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Pesticides",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            return PartialView("_AdsListingPartial", ads);
        }
        public IActionResult LoadPesticides(int count, int lastIndex)
        {
            var imagePath = Common.CommonValues.PEST_DEFAULT_PIC;
            List<AdViewModel> ads = new List<AdViewModel>();
            for (int i = 1; i <= count; i++)
            {
                ads.Add(new AdViewModel
                {
                    Category = "Pesticides",
                    Id = 1,
                    CategoryId = 1,
                    Location = "Lahore",
                    Picture = imagePath,
                    Price = "Rs. 10000",
                    Rating = 4,
                    Span = "15 mins ago",
                    Title = "Lorem Ipsum"
                });
            }
            return PartialView("_AdsListingPartial", ads);
        }
        [Route("/Products/Fertilizers")]
        public IActionResult ViewFertilizers() => View();
        public IActionResult GetFertilizers()
        {
            var imagePath = Common.CommonValues.FERTILIZER_DEFAULT_PIC;
            List<AdViewModel> ads = new List<AdViewModel>
            {
                new AdViewModel
                {
                    Category = "Fertilizers",
                    Id = 1,
                    CategoryId = 1,
                    Location = "Lahore",
                    Picture = imagePath,
                    Price = "Rs. 10000",
                    Rating = 4,
                    Span = "15 mins ago",
                    Title = "Lorem Ipsum"
                },
                new AdViewModel
                {
                    Category = "Fertilizers",
                    Id = 1,
                    CategoryId = 1,
                    Location = "Lahore",
                    Picture = imagePath,
                    Price = "Rs. 10000",
                    Rating = 4,
                    Span = "15 mins ago",
                    Title = "Lorem Ipsum"
                },
                new AdViewModel
                {
                    Category = "Fertilizers",
                    Id = 1,
                    CategoryId = 1,
                    Location = "Lahore",
                    Picture = imagePath,
                    Price = "Rs. 10000",
                    Rating = 4,
                    Span = "15 mins ago",
                    Title = "Lorem Ipsum"
                },
                new AdViewModel
                {
                    Category = "Fertilizers",
                    Id = 1,
                    CategoryId = 1,
                    Location = "Lahore",
                    Picture = imagePath,
                    Price = "Rs. 10000",
                    Rating = 4,
                    Span = "15 mins ago",
                    Title = "Lorem Ipsum"
                },
                new AdViewModel
                {
                    Category = "Fertilizers",
                    Id = 1,
                    CategoryId = 1,
                    Location = "Lahore",
                    Picture = imagePath,
                    Price = "Rs. 10000",
                    Rating = 4,
                    Span = "15 mins ago",
                    Title = "Lorem Ipsum"
                },
                new AdViewModel
                {
                    Category = "Fertilizers",
                    Id = 1,
                    CategoryId = 1,
                    Location = "Lahore",
                    Picture = imagePath,
                    Price = "Rs. 10000",
                    Rating = 4,
                    Span = "15 mins ago",
                    Title = "Lorem Ipsum"
                }
            };
            return PartialView("_AdsListingPartial", ads);
        }
        public IActionResult LoadFertilizers(int count, int lastIndex)
        {
            var imagePath = Common.CommonValues.FERTILIZER_DEFAULT_PIC;
            List<AdViewModel> ads = new List<AdViewModel>();
            for (int i = 1; i <= count; i++)
            {
                ads.Add(new AdViewModel
                {
                    Category = "Fertilizers",
                    Id = 1,
                    CategoryId = 1,
                    Location = "Lahore",
                    Picture = imagePath,
                    Price = "Rs. 10000",
                    Rating = 4,
                    Span = "15 mins ago",
                    Title = "Lorem Ipsum"
                });
            }
            return PartialView("_AdsListingPartial", ads);
        }
        [Route("/Products/Seeds/Crops")]
        public IActionResult ViewCropsSeeds()
        {
            return View();
        }
        public IActionResult GetCropsSeeds()
        {
            var imagePath = Common.CommonValues.CROP_DEFAULT_PIC;
            List<AdViewModel> ads = new List<AdViewModel>();
            ads.Add(new AdViewModel
            {
                Category = "Crops Seeds",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            return PartialView("_AdsListingPartial", ads);
        }
        public IActionResult LoadCropsSeeds(int count, int lastIndex)
        {
            var imagePath = Common.CommonValues.CROP_DEFAULT_PIC;
            List<AdViewModel> ads = new List<AdViewModel>();
            for (int i = 1; i <= count; i++)
            {
                ads.Add(new AdViewModel
                {
                    Category = "Crops",
                    Id = 1,
                    CategoryId = 1,
                    Location = "Lahore",
                    Picture = imagePath,
                    Price = "Rs. 10000",
                    Rating = 4,
                    Span = "15 mins ago",
                    Title = "Lorem Ipsum"
                });
            }
            return PartialView("_AdsListingPartial", ads);
        }
        [Route("/Products/Seeds/Fruits")]
        public IActionResult ViewFruitsSeeds()
        {
            return View();
        }
        public IActionResult GetFruitsSeeds()
        {
            var imagePath = Common.CommonValues.FRUIT_DEFAULT_PIC;
            List<AdViewModel> ads = new List<AdViewModel>();
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            return PartialView("_AdsListingPartial", ads);
        }
        public IActionResult LoadFruitsSeeds(int count, int lastIndex)
        {
            var imagePath = Common.CommonValues.FRUIT_DEFAULT_PIC;
            List<AdViewModel> ads = new List<AdViewModel>();
            for (int i = 1; i <= count; i++)
            {
                ads.Add(new AdViewModel
                {
                    Category = "Crops",
                    Id = 1,
                    CategoryId = 1,
                    Location = "Lahore",
                    Picture = imagePath,
                    Price = "Rs. 10000",
                    Rating = 4,
                    Span = "15 mins ago",
                    Title = "Lorem Ipsum"
                });
            }
            return PartialView("_AdsListingPartial", ads);
        }
        [Route("/Products/Seeds/Vegetables")]
        public IActionResult ViewVegetablesSeeds()
        {
            return View();
        }
        public IActionResult GetVegetablesSeeds()
        {
            var imagePath = Common.CommonValues.VEG_DEFAULT_PIC;
            List<AdViewModel> ads = new List<AdViewModel>();
            ads.Add(new AdViewModel
            {
                Category = "Vegetables",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Vegetables",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Vegetables",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Vegetables",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Vegetables",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            return PartialView("_AdsListingPartial", ads);
        }
        public IActionResult LoadVegetablesSeeds(int count, int lastIndex)
        {
            var imagePath = Common.CommonValues.VEG_DEFAULT_PIC;
            List<AdViewModel> ads = new List<AdViewModel>();
            for (int i = 1; i <= count; i++)
            {
                ads.Add(new AdViewModel
                {
                    Category = "Vegetables",
                    Id = 1,
                    CategoryId = 1,
                    Location = "Lahore",
                    Picture = imagePath,
                    Price = "Rs. 10000",
                    Rating = 4,
                    Span = "15 mins ago",
                    Title = "Lorem Ipsum"
                });
            }
            return PartialView("_AdsListingPartial", ads);
        }
    }
}