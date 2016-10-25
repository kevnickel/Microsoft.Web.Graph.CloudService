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
    public interface IStaticPageStorage
    {
        string GetStaticPageContent(string docName, string docCulture);
    }
}
