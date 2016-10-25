using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.Web.Graph.WebRole.ViewModels
{
    public class StaticHtmlViewModel : ViewModelBase
    {
        public StaticHtmlViewModel(HttpContext context) : base(context)
        {
        }

        public string StaticContent { get; set; }

        public string[] Styles { get; set; }
    }
}