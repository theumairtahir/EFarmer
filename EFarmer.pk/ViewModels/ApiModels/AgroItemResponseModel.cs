namespace EFarmer.pk.ViewModels.ApiModels
{
    /// <summary>
    /// Data model to request agro item api
    /// </summary>
    public class AgroItemResponseModel
    {
        /// <summary>
        /// Cateogry ot which it belongs
        /// </summary>
        public short Category { get; set; }
        /// <summary>
        /// Weight Scale in urdu
        /// </summary>
        public string UrduWeightScale { get; set; }
        /// <summary>
        /// Weight scale in english
        /// </summary>
        public string WeightScale { get; set; }
        /// <summary>
        /// Urdu name of the agro item
        /// </summary>
        public string UrduName { get; set; }
        /// <summary>
        /// Name of the Agro Item
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }
    }
}
