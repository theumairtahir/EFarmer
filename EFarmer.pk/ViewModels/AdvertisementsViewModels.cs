using EFarmer.Models.Helpers;

namespace EFarmer.pk.ViewModels.AdvertisementsViewModels
{
    public class UserInfoViewModel
    {
        public long Id { get; set; }
        public string DatePosted { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
    }
    public class FeaturedAdViewModel
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public short CategoryId { get; set; }
        public string Price { get; set; }
        public bool IsNegotiable { get; set; }
        public string Location { get; set; }
        public string Span { get; set; }
    }
    public class RecentAdsViewModel
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }
        public short CityId { get; set; }
    }
    public class AdDetailsViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public decimal Quantity { get; set; }
        public int Quality { get; set; }
        public string Price { get; set; }
        public string SellerMobileNumber { get; set; }
        public UserInfoViewModel _UserInfo { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string PostedDate { get; set; }
        public short CategoryId { get; set; }
        public GeoLocation CityLocation { get; set; }
        public short CityId { get; set; }   
    }
}