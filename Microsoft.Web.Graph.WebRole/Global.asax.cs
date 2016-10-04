using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Web.Portal.Common;
using Microsoft.Web.Portal.Common.Services;

namespace Microsoft.Web.Graph.WebRole
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //todo: we need to implement container mechanism to create teh service instance at the
            // start of the application and access that instance throughout the MVC Application
            ICultureService cultureService = new CultureService();
            cultureService.SetCurrentCulture(base.Context.Request);
        }
    }
}
