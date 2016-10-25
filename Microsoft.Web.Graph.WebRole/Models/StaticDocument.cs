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
        protected string _docName;
        protected string _docTitle;

        public string DocName
        {
            get { return _docName; }
            set { _docName = value; }
        }

        public string DocTitle
        {
            get { return _docTitle; }
            set { _docTitle = value; }
        }
    }

    /// <summary>
    /// Code Samples & SDKs page
    /// </summary>
    public class CodeSamplesAndSdks : StaticDocument
    {
        public CodeSamplesAndSdks()
        {
            this.DocName = "code-samples-and-sdks";
            this.DocTitle = Resources.StaticPage.Index.SAMPLES_AND_SDKS_TITLE;
        }
    }
}