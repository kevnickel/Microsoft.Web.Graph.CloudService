using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Microsoft.Web.Graph.WebRole.Controllers
{
    public class GraphExplorerController : BaseController
    {
        private string _viewName = "GraphExplorer";

        public string ViewName
        {
            get { return _viewName = "GraphExplorer"; }
        }

        //
        // GET: /GraphExplorer/

        public ActionResult Index()
        {
            return View(_viewName);
        }

    }
}
