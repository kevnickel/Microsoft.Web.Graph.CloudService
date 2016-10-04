using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Graph.WebRole.Util;
using DynamicDocs.Models;
using Microsoft.Web.Portal.Common.Services;

namespace Microsoft.Web.Graph.WebRole.Controllers
{
    public class DocPageController : BaseController
    {
        private ICultureService _cultureService = null;

        public DocPageController(ICultureService cultureService)
        {
            _cultureService = cultureService;
        }
        public ActionResult GetDocPage(string culture, string docPath)
        {
            DocMeta model = new DocMeta();
            model.DocToc = DocContentManager.GetToc(_cultureService.CurrentCulture, docPath);
            model.CurrentDocSets = DocContentManager.GetDocSets(_cultureService.CurrentCulture, docPath);
            model.InnerContent = DocContentManager.GetDocContent(_cultureService.CurrentCulture, docPath);
            model.DocPath = DocContentManager.GetDocShortPath(docPath);
            PreProcessDocModel(model);
            return View(model);
        }

        public ContentResult ClearAllTocCache()
        {
            DocContentManager.ClearTocCache();
            return Content("All Toc Cache cleared");
        }

        public ContentResult ClearTocCache(string culture, string productCategory, string docSetCategory)
        {
            if (string.IsNullOrEmpty(_cultureService.CurrentCulture) || string.IsNullOrEmpty(productCategory) || string.IsNullOrEmpty(docSetCategory))
            {
                return Content("Input paramters are incorrect, please follow below example:<br/>docpage/clearTocCache?cluture=en-us&productCategory=add-ins&docSetCategory=reference");
            }
            else
            {
                DocContentManager.ClearTocCache(_cultureService.CurrentCulture, productCategory, docSetCategory);
                return Content("Specifed Toc Cache cleared");
            }
        }

        public ContentResult ClearAllDocSetsCache()
        {
            DocContentManager.ClearDocSetsCache();
            return Content("All docsets Cache cleared");
        }

        public ContentResult ClearDocSetsCache(string culture, string productCategory)
        {
            DocContentManager.ClearDocSetsCache(_cultureService.CurrentCulture, productCategory);
            return Content("Sepcified docsets Cache cleared");
        }



        private void PreProcessDocModel(DocMeta model)
        {
            LinkCurrentDocSet(model);
            ContentNotFoundHandler(model);
            ProcessImages(model);
        }

        private void LinkCurrentDocSet(DocMeta model)
        {
            if (model.DocToc != null)
            {
                string docSetEntryFolderName = model.DocToc.RootPath;
                if (model.CurrentDocSets != null && model.CurrentDocSets.Item != null)
                {
                    foreach (DocSetsItem item in model.CurrentDocSets.Item)
                    {
                        if (item.EntryFolder.Equals(docSetEntryFolderName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            model.CurrentDocSet = item;
                            return;
                        }
                    }
                }
            }
        }

        private void ContentNotFoundHandler(DocMeta model)
        {
            if (model.InnerContent == null)
            {
                model.InnerContent = "<h1>Document not found.</h1>";
            }
        }
        private void ProcessImages(DocMeta model)
        {
            model.InnerContent = model.InnerContent.Replace("../../../images", "https://devofficecdn.azureedge.net/officedocuments/images")
            .Replace("../../images", "https://devofficecdn.azureedge.net/officedocuments/images")
            .Replace("../images", "https://devofficecdn.azureedge.net/officedocuments/images");
        }
    }
}