using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Microsoft.Web.Graph.WebRole.Controllers
{
    public class BaseController : Controller
    {
        protected void SetAppropriateContentType()
        {
            HttpContext.Response.ContentType = "text/html";
        }
    }
}