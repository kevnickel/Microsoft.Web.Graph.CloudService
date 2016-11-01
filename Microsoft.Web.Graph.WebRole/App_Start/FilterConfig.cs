using Microsoft.WindowsAzure.ServiceRuntime;
using System.Web;
using System.Web.Mvc;

namespace Microsoft.Web.Graph.WebRole
{
    public class FilterConfig
    {
        /// <summary>
        /// This property exists to support running under HTTP (the only time that you should run under HTTP
        /// is for development purposes, when you're accessing the constituent service implementation that
        /// is running on your local dev machine.)  If set to TRUE (as it is when running under Azure, but not
        /// under the Azure emulator), we will register a filter to validate, on each request, the incoming 
        /// client certificate.  
        /// </summary>
        public static bool ValidateFrontDoorCert
        {
            get { return RoleEnvironment.IsAvailable; }
        }

        /// <summary>
        /// Register Global Filters
        /// </summary>
        /// <param name="filters">Global filter collection</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            if (ValidateFrontDoorCert)
            {
                filters.Add(new ValidateFrontDoorCertificateAttribute());
            }
        }
    }
}
