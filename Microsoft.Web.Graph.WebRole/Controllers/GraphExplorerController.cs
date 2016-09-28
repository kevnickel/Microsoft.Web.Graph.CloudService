using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Microsoft.Web.Graph.WebRole.Controllers
{
    public class GraphExplorerController : BaseController
    {
        //
        // GET: /GraphExplorer/

        public ActionResult Index()
        {
            base.SetAppropriateContentType();
            return View();
        }

    }
}
