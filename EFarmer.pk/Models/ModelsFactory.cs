﻿using EFarmer.Connections;
using EFarmerPkModelLibrary.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFarmer.pk.Models
{
    /// <summary>
    /// Class to generate the models from repository
    /// </summary>
    public class ModelsFactory : RepositoryFactory
    {
        /// <summary>
        /// Initializer
        /// </summary>
        public ModelsFactory() : base(new BuildOptions { ConnectionString=Common.ConnectionStrings.CONNECTION_STRING })
        {
        }
    }
}
