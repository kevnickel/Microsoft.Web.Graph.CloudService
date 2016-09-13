using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DynamicDocs.Util;
using DynamicDocs.Models;

namespace DynamicDocs.Controllers
{
    public class DocPageController: Controller
    {
        public ActionResult GetDocPage(string docPath)
        {
            DocMeta model = new DocMeta();
                            model.DocToc = TocManager.GetToc();
                model.CurrentDocSets = TocManager.GetDocSets();
            if (docPath.ToLower() == "/docs/overview")
            {

                model.InnerContent = TocManager.ReadOnlineFile("https://ashirstest.blob.core.windows.net/dynamicdoc/office-add-ins.htm");
            }
            else
            {
                model.InnerContent = "404 not found.";
            }
            HttpContext.Response.ContentType = "text/fdxml";
            return View(model);
        }
    }
}