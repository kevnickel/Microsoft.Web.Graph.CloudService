//------------------------------------------------------------------------------
// <copyright file="BlobStaticPageStorage.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by kenick Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Class for getting static HTML content from blob storage
// </summary>
//------------------------------------------------------------------------------

namespace Microsoft.Web.Portal.Common.Storage
{
    using System.Globalization;
    using OfficeDevPortals.Shared.Storage;
    using Azure;

    public class BlobStaticPageStorage : IStaticPageStorage
    {
        /// <summary>
        /// Name of the container to find the pages
        /// </summary>
        /// <remarks>To be updated when container is finalized</remarks>
        private const string ContainerName = "kevinsdocs";

        /// <summary>
        /// The path to find the static html. First parameter is culture, second is filename.
        /// </summary>
        private const string Path = "graph-pages/{0}/{1}.htm";

        /// <summary>
        /// Retrieve the specified document from blob storage
        /// </summary>
        /// <param name="docName">The name of the document</param>
        /// <param name="docCulture">The culture of the document to retrieve</param>
        /// <returns>HTML content of the document</returns>
        public string GetContent(string docName, string docCulture)
        {
            string docPath = string.Format(CultureInfo.InvariantCulture, Path, docCulture.ToLower(CultureInfo.InvariantCulture), docName);
            return BlobManager.ReadContent(CloudConfigurationManager.GetSetting("StorageConnectionString"), ContainerName, docPath);
        }
    }
}
