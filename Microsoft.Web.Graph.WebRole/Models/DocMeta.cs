//------------------------------------------------------------------------------
// <copyright file="DocMeta.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by jnlxu Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Meta data for a dynamic document
// </summary>
//------------------------------------------------------------------------------

namespace Microsoft.Web.Graph.WebRole.Models
{
    /// <summary>
    /// Meta data for a dynamic document
    /// </summary>
    public class DocMeta
    {
        public Toc DocToc { get; set; }

        public DocSets CurrentDocSets { get; set; }

        public DocSetsItem CurrentDocSet { get; set; }

        public string InnerContent { get; set; }

        public string DocPath { get; set; }
    }
}