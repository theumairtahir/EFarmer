using System;

namespace EFarmer.pk.Areas.Admin.Models
{
    public class AdvertisementListingModel
    {
        public long Id { get; set; }
        public string ItemName { get; set; }
        public short Quality { get; set; }
        public string Quantity { get; set; }
        public string PostedTime { get; set; }
        public string Price { get; set; }
        public string Picture { get; set; }
        public string SellerName { get; set; }
        public string City { get; set; }
        public int Bids { get; set; }
        public string ActionButtons { get; set; }
    }
    public class BidChartModel
    {
        public DateTime Date { get; set; }
        public int NoOfBids { get; set; }
    }
}
