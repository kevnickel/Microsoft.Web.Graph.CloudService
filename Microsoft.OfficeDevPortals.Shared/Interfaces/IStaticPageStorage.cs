//------------------------------------------------------------------------------
// <copyright file="IStaticPageStorage.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by kenick Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Interface definition for getting static HTML content
// </summary>
//------------------------------------------------------------------------------

namespace Microsoft.OfficeDevPortals.Shared.Storage
{
    /// <summary>
    /// Interface definition for getting static HTML content
    /// </summary>
    public interface IStaticPageStorage
    {
        /// <summary>
        /// Retrieve the content of a page
        /// </summary>
        /// <param name="docName">The name of the doc to retrieve</param>
        /// <param name="docCulture">The culture of the doc to retrieve</param>
        /// <returns>The content of the specified document</returns>
        string GetContent(string docName, string docCulture);
    }
}
