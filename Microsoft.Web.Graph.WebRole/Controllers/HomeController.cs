//------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by ashirs Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Default controller
// </summary>
//------------------------------------------------------------------------------

using System.Web.Mvc;
using Microsoft.OfficeDevPortals.Shared.Culture;
using Microsoft.OfficeDevPortals.Shared.Logging;
using Microsoft.OfficeDevPortals.Shared.Telemetry;
using Microsoft.Web.Graph.WebRole.ViewModels;

namespace Microsoft.Web.Graph.WebRole.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ICultureService cultureService, ILogger logger, ITelemetry telemetry) : base(cultureService, logger, telemetry)
        {
        }

        public ActionResult Index()
        {
            ViewModelBase model = new ViewModelBase(HttpContext.ApplicationInstance.Context);
            model.PageTitle = "Microsoft Graph - Home";
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}