//------------------------------------------------------------------------------
// <copyright file="StaticDocument.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by kenick Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Static documents used in Graph portal
// </summary>
//------------------------------------------------------------------------------

namespace Microsoft.Web.Graph.WebRole.Models
{
    /// <summary>
    /// A generic document
    /// </summary>
    public abstract class StaticDocument
    {
        private string _docName;
        private string _docTitle;

        /// <summary>
        /// The name of the document
        /// </summary>
        public string DocName
        {
            get { return _docName; }
            set { _docName = value; }
        }

        /// <summary>
        /// The title of the document
        /// </summary>
        public string DocTitle
        {
            get { return _docTitle; }
            set { _docTitle = value; }
        }
    }
}