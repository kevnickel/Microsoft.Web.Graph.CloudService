//------------------------------------------------------------------------------
// <copyright file="BaseController.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by ashirs Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Base class for graph portal controllers
// </summary>
//------------------------------------------------------------------------------

using System.Web.Mvc;
using Microsoft.OfficeDevPortals.Shared.Culture;
using Microsoft.OfficeDevPortals.Shared.Logging;
using Microsoft.OfficeDevPortals.Shared.Telemetry;

namespace Microsoft.Web.Graph.WebRole.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ILogger Logger = null;
        protected ITelemetry Telemetry = null;
        protected ICultureService CultureService = null;

        protected BaseController(ICultureService cultureService, ILogger logger, ITelemetry telemetry)
        {
            CultureService = cultureService;
            Logger = logger;
            Telemetry = telemetry;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsLocal == true)
            {
                HttpContext.Response.ContentType = "text/html";
            }
            else
            {
                HttpContext.Response.ContentType = "text/fdxml";
            }
        }
    }
}