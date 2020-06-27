using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EFarmer.pk.Common
{
    public static class Controllers
    {
        private static readonly List<Type> classes;
        static Controllers()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            classes = assembly.GetTypes().ToList();
        }

        public static List<string> GetApiControllerNames()
        {
            var apiControllers = classes.Where(x =>
            {
                try
                {
                    var namespaceName = x.Namespace;
                    var result = (namespaceName.Contains("ApiControllers")
                                && !(x.Name.Contains("<") ||
                                x.Name.Contains(">")));
                    return result;
                }
                catch (Exception)
                {
                    return false;
                }
            })
            .Select(x => x.Name)
            .ToList();
            return apiControllers;
        }
    }
}
