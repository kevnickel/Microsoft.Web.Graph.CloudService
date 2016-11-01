//------------------------------------------------------------------------------
// <copyright file="DocPageController.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by jnlxu Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Controller for serving Graph Portal documents
// </summary>
//------------------------------------------------------------------------------

namespace Microsoft.Web.Graph.WebRole.Controllers
{
    using System;
    using System.Globalization;
    using System.Web.Mvc;
    using Microsoft.Web.Graph.WebRole.Models;
    using Microsoft.Web.Graph.WebRole.Utilities;
    using Microsoft.OfficeDevPortals.Shared.Enums;
    using Microsoft.OfficeDevPortals.Shared.Telemetry;
    using Microsoft.OfficeDevPortals.Shared.Logging;
    using Microsoft.OfficeDevPortals.Shared.Culture;

    public class DocPageController : BaseController
    {
        public DocPageController(ICultureService cultureService, ILogger logger, ITelemetry telemetry) : base(cultureService, logger, telemetry)
        {
        }

        public ActionResult GetDocPage(string docPath)
        {
            Logger.Log(SharedEnums.LogLevel.Debug, string.Format(CultureInfo.InvariantCulture, "Retrieving document at '{0}'", docPath));
            Telemetry.TrackEvent("GetDocPage");
            DocMeta model = new DocMeta();
            model.DocToc = DocContentManager.GetToc(CultureService.CurrentCulture, docPath);
            model.CurrentDocSets = DocContentManager.GetDocSets(CultureService.CurrentCulture, docPath);
            model.InnerContent = DocContentManager.GetDocContent(CultureService.CurrentCulture, docPath);
            model.DocPath = DocContentManager.GetDocShortPath(docPath);
            PreProcessDocModel(model);
            return View(model);
        }

        public ContentResult ClearAllTocCache()
        {
            DocContentManager.ClearTocCache();
            return Content("All Toc Cache cleared");
        }

        public ContentResult ClearTocCache(string productCategory, string docSetCategory)
        {
            if (string.IsNullOrEmpty(CultureService.CurrentCulture) || string.IsNullOrEmpty(productCategory) || string.IsNullOrEmpty(docSetCategory))
            {
                return Content("Input paramters are incorrect, please follow below example:<br/>docpage/clearTocCache?cluture=en-us&productCategory=add-ins&docSetCategory=reference");
            }
            else
            {
                DocContentManager.ClearTocCache(CultureService.CurrentCulture, productCategory, docSetCategory);
                return Content("Specifed Toc Cache cleared");
            }
        }

        public ContentResult ClearAllDocSetsCache()
        {
            DocContentManager.ClearDocSetsCache();
            return Content("All docsets Cache cleared");
        }

        public ContentResult ClearDocSetsCache(string productCategory)
        {
            DocContentManager.ClearDocSetsCache(CultureService.CurrentCulture, productCategory);
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