using EFarmer.Models.Helpers;
using Microsoft.Extensions.Configuration;
using System;
namespace EFarmer.pk.Common
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class CommonValues
    {
        public static readonly string APP_NAME = "e-Farmer";
        public static readonly string APP_NAME_PART = ".pk";
        public static readonly string CROP_DEFAULT_PIC = "agri_crop.jpg";
        public static readonly string SEEDS_DEFAULT_PIC = "agri_seed.jpg";
        public static readonly string VEG_DEFAULT_PIC = "agri_veg.jpg";
        public static readonly string FRUIT_DEFAULT_PIC = "agri_fruit.jpg";
        public static readonly string FERTILIZER_DEFAULT_PIC = "agri_fertilizer.jpg";
        public static readonly string PEST_DEFAULT_PIC = "agri_pest.jpg";
        public static readonly string BLOG_DATE_FORMAT = "MMMM dd, yyyy";
        public static readonly double RADIUS_IN_KM = 25;
        public static readonly double RADIUS_IN_MILES = 25;
        public static readonly double CONTINOUS_SCROLL_PERCENT = 70;
        public static readonly string CURRENCY_SYMBOL = "Rs.";
        public static readonly string UPLOADED_PICS_PATH = @"~/uploaded_images/";
        public static readonly string PROFILE_IMAGES_PATH = @"~/images/profile-images/";
        public static readonly string DEFAULT_PROFILE_IMAGE = "profile.jpg";
        public static readonly string LONG_DATE_FORMAT = "dd MMMM, yy";
        public static readonly string UPDATE_MESSAGE = "Updated Successfully";
        public static readonly string DELETE_MESSAGE = "Your data has been deleted";
        public static readonly string ADD_MESSAGE = "Added Successfully";
        public static readonly string CREATE_CAPTION = "Create New";
        public static readonly GeoLocation DEFAULT_LOCATION = new GeoLocation { Latitude = 31.478657m, Longitude = 74.287981m };
        static CommonValues()
        {
            //getting connection string from appsettings.json
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .SetBasePath(projectPath)
            //    .AddJsonFile("appsettings.json")
            //    .Build();
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
