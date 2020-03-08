using EFarmer.Models.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
    public class PostAdViewModel
    {
        [Required]
        [Display(Name = "Agro Item")]
        public int ItemId { get; set; }
        [Required]
        [Display(Name = "Category")]
        public short CityId { get; set; }
        public IEnumerable<IFormFile> Files { get; set; }
        [Required]
        [Display(Name = "Quality")]
        public short Quality { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public short Quantity { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string SellerFirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string SellerLastName { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "It should be a country code like +92", MinimumLength = 3)]
        public string SellerCountryCode { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "It should be a company code like 300", MinimumLength = 3)]
        public string SellerComapanyCode { get; set; }
        [Required]
        [StringLength(7, ErrorMessage = "It should be a valid number like 1234567", MinimumLength = 7)]
        public string SellerNumber { get; set; }
        [Required]
        public string SellerAddress { get; set; }
        public short SellerCity { get; set; }
    }
}