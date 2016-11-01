//------------------------------------------------------------------------------
// <copyright file="GraphExplorerController.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by ashirs Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Controller for serving the GraphExplorer
// </summary>
//------------------------------------------------------------------------------

using System.Web.Mvc;
using Microsoft.OfficeDevPortals.Shared.Culture;
using Microsoft.OfficeDevPortals.Shared.Logging;
using Microsoft.OfficeDevPortals.Shared.Telemetry;

namespace Microsoft.Web.Graph.WebRole.Controllers
{
    public class GraphExplorerController : BaseController
    {
        public GraphExplorerController(ICultureService cultureService, ILogger logger, ITelemetry telemetry) : base(cultureService, logger, telemetry)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
