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
            Assembly assembly = Assembly.GetExecutingAssembly();
            //var controllerNames = assembly.GetTypes().Where(x => string.Equals(x.Namespace, "Controllers", StringComparison.Ordinal));
            if (action.Controller.ControllerName.Contains("Products"))
            {
                action.ApiExplorer.IsVisible = false;
            }
            else if (action.Controller.ControllerName.Contains("Home"))
            {
                action.ApiExplorer.IsVisible = false;
            }
            else if (action.Controller.ControllerName.Contains("Products"))
            {
                action.ApiExplorer.IsVisible = false;
            }
            else if (action.Controller.ControllerName.Contains("Blogs"))
            {
                action.ApiExplorer.IsVisible = false;
            }
            else if (action.Controller.ControllerName.Contains("Advertisments"))
            {
                action.ApiExplorer.IsVisible = false;
            }
        }
    }
}
