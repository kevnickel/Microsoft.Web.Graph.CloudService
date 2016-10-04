using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Microsoft.Web.Portal.Common.Services
{
    public class CultureService : ICultureService
    {
        /// <summary>
        /// Supported culture by current service
        /// </summary>
        private readonly static string _supportCultures = @"[/-]ja-jp/?|[/-]de-de/?|[/-]zh-cn/?|[/-]en-us/?";

        /// <summary>
        /// Default culture in case unsupported culture is requested
        /// </summary>
        private readonly static string _defaultCulture = "en-us";

        /// <summary>
        /// Current culture
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
            Match mt = Regex.Match(httpRequest.Url.AbsolutePath, _supportCultures, RegexOptions.IgnoreCase);
            if (mt.Length > 0)
            {
                culture = mt.Value.Trim(new char[] { '/', '-' }).ToLowerInvariant();
            }
            CurrentCulture = culture;
        }

    }
}
