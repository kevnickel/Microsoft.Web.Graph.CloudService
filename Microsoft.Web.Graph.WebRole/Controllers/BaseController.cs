//------------------------------------------------------------------------------
// <copyright file="BaseController.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by ashirs Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Base class for graph portal controllers
// </summary>
//------------------------------------------------------------------------------

namespace Microsoft.Web.Graph.WebRole.Controllers
{
    using System.Web.Mvc;
    using OfficeDevPortals.Shared.Culture;
    using OfficeDevPortals.Shared.Logging;
    using OfficeDevPortals.Shared.Telemetry;

    /// <summary>
    /// Base class for graph portal controllers
    /// </summary>
    public abstract class BaseController : Controller
    {
        private ILogger _logger = null;
        private ITelemetry _telemetry = null;
        private ICultureService _cultureService = null;

        /// <summary>
        /// Logging implementation
        /// </summary>
        protected ILogger Logger
        {
            get { return _logger; }
            set { _logger = value; }
        }

        /// <summary>
        /// Telemetry implementation
        /// </summary>
        protected ITelemetry Telemetry
        {
            get { return _telemetry; }
            set { _telemetry = value; }
        }

        /// <summary>
        /// Culture service implementation
        /// </summary>
        protected ICultureService CultureService
        {
            get { return _cultureService; }
            set { _cultureService = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class
        /// </summary>
        /// <param name="cultureService">Culture service implementation</param>
        /// <param name="logger">Logging implementation</param>
        /// <param name="telemetry">Telemetry implementation</param>
        protected BaseController(ICultureService cultureService, ILogger logger, ITelemetry telemetry)
        {
            _cultureService = cultureService;
            _logger = logger;
            _telemetry = telemetry;
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