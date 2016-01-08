using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject.Web;
using Task2_CarOwners;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWeb), "Start")]

namespace Task2_CarOwners
{
    public static class NinjectWeb 
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        }
    }
}
