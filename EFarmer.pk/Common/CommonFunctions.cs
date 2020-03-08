using ImageMagick;
using System;
using System.IO;

namespace EFarmer.pk.Common
{
    public static class CommonFunctions
    {
        public static void CompressImage(string path)
        {
            FileInfo file = new FileInfo(path);
            using (MagickImage image = new MagickImage(file))
            {
                image.Resize(720, 0);
                image.Quality = 50;
                image.Crop(720, 550);
                image.Scale(720, 550);
                image.Write(file);
            }
        }
        public static string GetAdTitle(string sellerName, string agroItem,string city)
        {
            return sellerName + " is selling " + agroItem + " in " + city;
        }
        public static string GetPassedTimeSpanFromNow(DateTime time)
        {
            string s = time.ToString("dd-mmm-yyyy hh:mm:ss");
            TimeSpan span = DateTime.Now - time;
            var mins = decimal.Round(Convert.ToDecimal(span.TotalMinutes));
            var hrs = decimal.Round(Convert.ToDecimal(span.TotalHours));
            var days = decimal.Round(Convert.ToDecimal(span.TotalDays));
            if (mins < 1)
            {
                s = "Just Now";
            }
            else if (hrs < 1)
            {
                if (mins == 1)
                {
                    s = "1 minute ago";
                }
                else
                {
                    s = mins + " minutes ago";
                }
            }
            else if (days < 1)
            {
                if (hrs == 1)
                {
                    s = "1 hour ago";
                }
                else
                {
                    s = hrs + " hours ago";
                }
            }
            else if (days == 1)
            {
                s = "1 day ago";
            }
            else if (days < 31)
            {
                s = days + " days ago";
            }
            return s;
        }
        public static string GetPassedDateSpanFromNow(DateTime date)
        {
            string s = date.ToString("dd-mmm-yyyy");
            TimeSpan span = DateTime.Now - date;
            var days = decimal.Round(Convert.ToDecimal(span.TotalDays));
            if (days < 1)
            {
                s = "Less than a day";
            }
            else if (days < 31)
            {
                s = days + " days ago";
            }
            return s;
        }
    }
}
