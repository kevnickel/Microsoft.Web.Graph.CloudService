//------------------------------------------------------------------------------
// <copyright file="CodeSamplesAndSdks.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by kenick Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Code Samples & SDKs page
// </summary>
//------------------------------------------------------------------------------

namespace Microsoft.Web.Graph.WebRole.Models
{
    /// <summary>
    /// Code Samples & SDKs page
    /// </summary>
    public class CodeSamplesAndSDKs : StaticDocument
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CodeSamplesAndSDKs()
        {
            this.DocName = "code-samples-and-sdks";
            this.DocTitle = Resources.StaticPage.Index.SAMPLES_AND_SDKS_TITLE;
        }
    }
}