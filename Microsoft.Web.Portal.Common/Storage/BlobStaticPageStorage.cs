//------------------------------------------------------------------------------
// <copyright file="BlobStaticPageStorage.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by kenick Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Class for getting static HTML content from blob storage
// </summary>
//------------------------------------------------------------------------------

using System;
using System.Globalization;
using Microsoft.OfficeDevPortals.Shared.Storage;
using Microsoft.Azure;

namespace Microsoft.Web.Portal.Common.Storage
{
    public class BlobStaticPageStorage : IStaticPageStorage
    {
        private const string ContainerName = "kevinsdocs";
        private const string Path = "graph-pages/{0}/{1}.htm";

        /// <summary>
        /// Retrieve the specified document from blob storage
        /// </summary>
        /// <param name="docName">The name of the document</param>
        /// <param name="culture">The culture of the document to retrieve</param>
        /// <returns>HTML content of the document</returns>
        public string GetStaticPageContent(string docName, string culture)
        {
            string docPath = String.Format(CultureInfo.InvariantCulture, Path, culture, docName);
            return BlobManager.ReadContent(CloudConfigurationManager.GetSetting("StorageConnectionString"), ContainerName, docPath);
        }
    }
}
