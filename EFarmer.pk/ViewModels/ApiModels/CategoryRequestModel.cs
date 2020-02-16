namespace EFarmer.pk.ViewModels.ApiModels
{
    /// <summary>
    /// Data carrier for category
    /// </summary>
    public class CategoryRequestModel
    {
        /// <summary>
        /// Urdu name of the category
        /// </summary>
        public string UrduName { get; set; }
        /// <summary>
        /// Name of the category
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Primary Key
        /// </summary>
        public short Id { get; set; }
    }
}
