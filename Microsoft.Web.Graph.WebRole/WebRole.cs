using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Web.Administration;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace Microsoft.Web.Graph.WebRole
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            if (RoleEnvironment.IsAvailable && !RoleEnvironment.IsEmulated)
            {
                // For information on handling configuration changes
                // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
                try
                {
                    using (var server = new ServerManager())
                    {
                        var siteNameFromServiceModel = "Web";
                        var siteName = string.Format("{0}_{1}", RoleEnvironment.CurrentRoleInstance.Id,
                            siteNameFromServiceModel);

                        var config = server.GetApplicationHostConfiguration();
                        var accessSection = config.GetSection("system.webServer/security/access", siteName);
                        accessSection["sslFlags"] = @"Ssl,SslNegotiateCert";

                        server.CommitChanges();
                    }
                }
                catch (Exception)
                {
                    // If anything goes wrong with service initialization, you should do appropriate logging
                    // and rethrow.  

                    throw;
                }
            }

            return base.OnStart();
        }
    }
}
