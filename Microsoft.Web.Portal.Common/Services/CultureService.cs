using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Microsoft.Web.Portal.Common
{
    public class CultureService
    {
        private readonly static string supportCultures = @"[/-]ja-jp/?|[/-]de-de/?|[/-]zh-cn/?|[/-]en-us/?";

        public static string CurrentCulture
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

        public static void SetCurrentCulture(HttpRequest request)
        {
            Match mt = Regex.Match(request.Url.AbsolutePath, supportCultures, RegexOptions.IgnoreCase);
            if (mt.Length <= 0)
                return;
            CurrentCulture = mt.Value.Trim(new char[] { '/', '-' }).ToLowerInvariant();
        }
    }
}
