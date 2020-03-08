using Microsoft.Extensions.Configuration;
using System;
namespace EFarmer.pk.Common
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class CommonValues
    {
        public static readonly string APP_NAME = "e-Farmer";
        public static readonly string APP_NAME_PART = ".pk";
        //public static readonly string CONNECTION_STRING;
        public static readonly string CROP_DEFAULT_PIC = "agri_crop.jpg";
        public static readonly string VEG_DEFAULT_PIC = "agri_veg.jpg";
        public static readonly string FRUIT_DEFAULT_PIC = "agri_fruit.jpg";
        public static readonly string FERTILIZER_DEFAULT_PIC = "agri_fertilizer.jpg";
        public static readonly string PEST_DEFAULT_PIC = "agri_pest.jpg";
        public static readonly string BLOG_DATE_FORMAT = "MMMM dd, yyyy";
        public static readonly double RADIUS_IN_KM = 25;
        public static readonly double RADIUS_IN_MILES = 25;
        public static readonly double CONTINOUS_SCROLL_PERCENT = 85;
        public static readonly string CURRENCY_SYMBOL = "Rs.";
        public static readonly string UPLOADED_PICS_PATH = @"~/uploaded_images/";
        static CommonValues()
        {
            //getting connection string from appsettings.json
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();
            //CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //CONNECTION_STRING = configuration.GetConnectionString("Data:DefaultConnection");
            //CONNECTION_STRING = @"Data Source=tcp:efarmerpkdbserver.database.windows.net,1433;Initial Catalog=EFarmerDb;User Id=efarmerdb@efarmerpkdbserver;Password=@admin12345";
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
