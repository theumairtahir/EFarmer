using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFarmer.pk.Areas.Admin.Models
{
    public class CitiesListingViewModel
    {
        public int Id { get; set; }
        public string ActionButtons { get; set; }
        public string Name { get; set; }
    }
    public class CityViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "City Name")]
        [StringLength(50, ErrorMessage = "The City Name must be less than 50 characters")]
        public string Name { get; set; }
    }
    public class PieChartViewModel
    {
        public List<RoseChartModel> Legend { get; set; }
        public List<string> Labels
        {
            get
            {
                return Legend.Select(x => x.Label).ToList();
            }
        }
        public List<string> Colors
        {
            get
            {
                return Legend.Select(x => x.Color).ToList();
            }
        }
        public List<PieChartData> Data
        {
            get
            {
                return (Legend.Select(x => new PieChartData
                {
                    Name = x.Label,
                    Value = x.Value
                }).ToList());
            }
        }
    }
    public class RoseChartModel : ChartLabel
    {
        public int Value { get; set; }
    }
    public class PieChartData
    {
        public int Value { get; set; }
        public string Name { get; set; }
    }
    public class BarChartModel : ChartLabel
    {
        public List<BarChartData> Data { get; set; }

    }
    public class BarChartViewModel
    {
        public List<BarChartModel> Ledgend { get; set; }
        public List<string> Labels
        {
            get
            {
                return Ledgend.Select(x => x.Label).ToList();
            }
        }
        public List<string> Colors
        {
            get
            {
                return Ledgend.Select(x => x.Color).ToList();
            }
        }
        //public List<decimal[]> Data
        //{
        //    get
        //    {
        //        return Ledgend.Select(x => x.Data.Select(y => y.Value).ToArray()).ToList();
        //    }
        //}
        public List<string> Categories
        {
            get
            {
                return Ledgend[0].Data.Select(x => x.Category).ToList();
            }
        }
        public List<BarChartResultView> Data
        {
            get
            {
                return Ledgend.Select(x =>
                                new BarChartResultView
                                {
                                    Name = x.Label,
                                    Data = x.Data.Select(y => y.Value)
                                    .ToList()
                                }).ToList();
            }
        }
    }
    public class BarChartResultView
    {
        public string Name { get; set; }
        public List<decimal> Data { get; set; }
    }
    public class BarChartData
    {
        public string Category { get; set; }
        public decimal Value { get; set; }
    }
}
