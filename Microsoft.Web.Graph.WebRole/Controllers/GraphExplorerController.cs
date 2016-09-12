using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Microsoft.Web.Graph.WebRole.Controllers
{
    public class GraphExplorerController : Controller
    {
        //
        // GET: /GraphExplorer/

        public ActionResult Index()
        {
            HttpContext.Response.ContentType = "text/html";
            return View();
        }

    }
}
