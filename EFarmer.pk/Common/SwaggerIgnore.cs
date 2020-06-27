using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EFarmer.pk.Common
{
    public class SwaggerIgnore : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            if (!Controllers
                .GetApiControllerNames()
                .Any(x => x.Contains(action.Controller.ControllerName)))
            {
                action.ApiExplorer.IsVisible = false;
            }
        }
    }
}
