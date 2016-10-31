//------------------------------------------------------------------------------
// <copyright file="StaticPageController.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by kenick Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Serve static HTML from storage
// </summary>
//------------------------------------------------------------------------------

namespace Microsoft.Web.Graph.WebRole.Controllers
{
    using Models.StaticDocuments;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;
    using OfficeDevPortals.Shared.Enums;
    using OfficeDevPortals.Shared.Logging;
    using OfficeDevPortals.Shared.Telemetry;
    using OfficeDevPortals.Shared.Culture;
    using OfficeDevPortals.Shared.Storage;
    using ViewModels;

    public class StaticPageController : BaseController
    {
        /// <summary>
        /// Used to retrieve documents
        /// </summary>
        private readonly IStaticPageStorage _docStorage;
        /// <summary>
        /// List of static pages the controller will retrieve
        /// </summary>
        private readonly List<StaticDocument> _documents;

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticPageController"/> class
        /// </summary>
        /// <param name="cultureService">Culture service for this instance</param>
        /// <param name="logger">Logger to use for this instance</param>
        /// <param name="telemetry">Telemetry to use for this instance</param>
        /// <param name="docStorage">Interface to static html storage</param>
        public StaticPageController(ICultureService cultureService, ILogger logger, ITelemetry telemetry, IStaticPageStorage docStorage) : base(cultureService, logger, telemetry)
        {
            this._docStorage = docStorage;
            this._documents = new List<StaticDocument>()
            {
                new CodeSamplesAndSdks()
            };
        }

        /// <summary>
        /// Retrieve the static page specified
        /// </summary>
        /// <param name="docName">The name of the document on blob storage to retrieve</param>
        /// <returns>The html document from storage</returns>
        public ActionResult GetStaticPage(string docName)
        {
            this.Logger.Log(SharedEnums.LogLevel.Information, string.Format(CultureInfo.InvariantCulture, "Retrieve document '{0}' from blob", docName));

            StaticHtmlViewModel model = new StaticHtmlViewModel(HttpContext.ApplicationInstance.Context);
            model.PageTitle = this._documents
                .Where(doc => doc.DocName == docName)
                .Select(doc => doc.DocTitle).First();
            this.Logger.Log(SharedEnums.LogLevel.Information,
                string.Format(CultureInfo.InvariantCulture,
                "Found document title '{0}' for document '{1}'", 
                model.PageTitle,
                    docName));
            model.Styles = new string[] { "/" + CultureService.CurrentCulture + "/graph-test/Content/build/css/msgraph-portal.css" };
            model.StaticContent = this._docStorage.GetContent(docName, CultureService.CurrentCulture.ToLower());
            this.Logger.Log(SharedEnums.LogLevel.Information, string.Format(CultureInfo.InvariantCulture, "Found content for '{0}': {1}", docName, !string.IsNullOrEmpty(model.StaticContent)));

            return View(model);
        }
    }
}