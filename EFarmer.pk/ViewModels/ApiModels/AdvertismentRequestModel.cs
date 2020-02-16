namespace EFarmer.pk.ViewModels.ApiModels
{
    /// <summary>
    /// Model for the advertisement
    /// </summary>
    public class AdvertismentRequestModel
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Item Related to this advertisement
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// City to which this advertisment belongs
        /// </summary>
        public short CityId { get; set; }
        /// <summary>
        /// Seller who posted the advertisement
        /// </summary>
        public long Seller { get; set; }
        /// <summary>
        /// Price setteled by the seller
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity of the items
        /// </summary>
        public short Quantity { get; set; }
        /// <summary>
        /// Quality of the items
        /// </summary>
        public short Quality { get; set; }
    }
}
