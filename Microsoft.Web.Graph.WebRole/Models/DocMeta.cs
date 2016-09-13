using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicDocs.Models
{
    public class DocMeta
    {
        public Toc DocToc { get; set; }

        public DocSets CurrentDocSets { get; set; }

        public string InnerContent { get; set; }
    }
}