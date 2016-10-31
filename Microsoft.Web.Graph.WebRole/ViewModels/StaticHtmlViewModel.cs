//------------------------------------------------------------------------------
// <copyright file="StaticHtmlViewModel.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by kenick Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      ViewModel for displaying static html content
// </summary>
//------------------------------------------------------------------------------

namespace Microsoft.Web.Graph.WebRole.ViewModels
{
    using System.Web;

    /// <summary>
    /// ViewModel for displaying static html content
    /// </summary>
    public class StaticHtmlViewModel : ViewModelBase
    {
        /// <summary>
        /// Constructure
        /// </summary>
        /// <param name="context">HttpContext for this ViewModel</param>
        public StaticHtmlViewModel(HttpContext context) : base(context)
        {
        }

        /// <summary>
        /// The HTML to display
        /// </summary>
        public string StaticContent { get; set; }

        /// <summary>
        /// URI's of css used by StaticContent
        /// </summary>
        public string[] Styles { get; set; }
    }
}