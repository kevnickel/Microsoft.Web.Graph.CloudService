using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DynamicDocs.Util;
using DynamicDocs.Models;

namespace Microsoft.Web.Graph.WebRole.Controllers
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

        public ActionResult NotFound()
        {
            string originalUrl = Request.RawUrl.ToLower();
            if(originalUrl.StartsWith("/en-us/"))
            {
                return View();
            }
            else
            {
                Response.Redirect("/en-us/" + GetUrlWithOutCulture(originalUrl));
            }
            return null;
        }

        private string GetUrlWithOutCulture(string url)
        {
            List<string> cultures = new List<string>();
            cultures.Add("/ja-jp/");
            cultures.Add("/zh-cn/");
            cultures.Add("/de-de/");
            foreach (string culture in cultures)
            {
                if (url.StartsWith(culture))
                {
                    return url.Substring(6);
                }
            }
            return url;
        }
    }
}