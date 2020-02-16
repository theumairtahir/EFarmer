using EFarmer.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFarmer.pk.ViewModels.ApiModels
{
    /// <summary>
    /// Api Model for City
    /// </summary>
    public class CityResponseModel
    {
        /// <summary>
        /// Name of the City
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Location of Existence
        /// </summary>
        public GeoLocation Location { get; set; }
        /// <summary>
        /// Primary Key
        /// </summary>
        public short Id { get; set; }
    }
}
