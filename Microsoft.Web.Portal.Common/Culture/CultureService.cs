//------------------------------------------------------------------------------
// <copyright file="CultureService.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     Developed by keithmg, ashirs, patrickp Office Developer Experience Engineering Team 
// </copyright>
// <summary>
//      Culture Service
// </summary>
//------------------------------------------------------------------------------
namespace Microsoft.Web.Portal.Common.Culture
{
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Web;
    using OfficeDevPortals.Shared.Culture;

    /// <summary>
    /// Culture Service Class 
    /// </summary>
    public class CultureService : ICultureService
    {
        /// <summary>
        /// Supported culture by current service
        /// </summary>
        private readonly string _supportCultures = null;

        /// <summary>
        /// Default culture in case unsupported culture is requested
        /// </summary>
        private readonly string _defaultCulture = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CultureService" /> class.
        /// </summary>
        /// <param name="defaultCulture">default culture</param>
        /// <param name="supportedCulture">supported culture</param>
        public CultureService(string defaultCulture, string supportedCulture)
        {
            _defaultCulture = defaultCulture;
            _supportCultures = supportedCulture;
        }

        /// <summary>
        /// Gets the Current culture
        /// </summary>
        public string CurrentCulture
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture.Name;
            }

            private set
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(value);
            }
        }

        /// <summary>
        /// Sets the current culture based on current Http Request
        /// </summary>
        /// <param name="httpRequest">current http request</param>
        public void SetCurrentCulture(HttpRequest httpRequest)
        {
            string culture = _defaultCulture;
            if (httpRequest != null)
            {
                Match match = Regex.Match(httpRequest.Url.AbsolutePath, _supportCultures, RegexOptions.IgnoreCase);
                if (match.Length > 0)
                {
                    culture = match.Value.Trim(new char[] { '/', '-' }).ToUpperInvariant();
                }
            }

            this.CurrentCulture = culture;
        }
    }
}
