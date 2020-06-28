using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFarmer.pk.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public string TotalAds { get; set; }
        public string TotalUsers { get; set; }
        public string NewAdsPercent { get; set; }
        public string NewUsersPercent { get; set; }
        public bool IsNewUsersUp { get; set; }
        public bool IsNewAdsUp { get; set; }
        public string BuyersCount { get; set; }
        public string CropsCount { get; set; }
        public string SellersCount { get; set; }
        public string CitiesCount { get; set; }
    }
    public class AdPostedChartModel
    {
        public DateTime Month { get; set; }
        public int Lahore { get; set; }
        public int Bahawalpur { get; set; }
        public int Faisalabad { get; set; }
    }
    public class TimelineBarChartModel
    {
        public string ElementId { get; set; }
        public List<int> Values { get; set; }
        public string Color { get; set; }
    }
    public class SeasonalOverviewViewModel
    {
        public string ElementId { get; set; }
        public List<ChartLabel> Labels { get; set; }
        public List<string> Colors
        {
            get
            {
                return Labels.Select(x => x.Color).ToList();
            }
        }
        public List<SeasonalOverviewChartModel> Data { get; set; }
    }
    public class ChartLabel
    {
        public string Color { get; set; }
        public string Label { get; set; }
    }
    public class SeasonalOverviewChartModel
    {
        public string Crop { get; set; }
        public double Season1 { get; set; }
        public double Season2 { get; set; }
        public double Season3 { get; set; }
        public double Season4 { get; set; }
    }
    public class PopularityChartModel
    {
        public string Day { get; set; }
        public int CurrentMonth { get; set; }
        public int PrevMonth { get; set; }
    }
    public class PopularityChartViewModel
    {
        public List<ChartLabel> Labels { get; set; }
        public List<string> Colors
        {
            get
            {
                return Labels.Select(x => x.Color).ToList();
            }
        }
        public List<string> LabelNames
        {
            get
            {
                return Labels.Select(x => x.Label).ToList();
            }
        }
        public List<PopularityChartModel> Data { get; set; }
    }
}
