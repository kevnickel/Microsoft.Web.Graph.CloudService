using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

namespace DynamicDocs.Util
{
    public class TocManager
    {
        private static Toc testToc;
        private static DocSets testDocSets;

        public static Toc GetToc()
        {
            if (testToc == null)
            {
                string content = ReadOnlineFile("https://ashirstest.blob.core.windows.net/dynamicdoc/toc.xml");
                testToc = XmlReader.GetOject<Toc>(content);

            }
            return testToc;
        }

        public static DocSets GetDocSets()
        {
            if (testDocSets == null)
            {
                string content = ReadOnlineFile("https://ashirstest.blob.core.windows.net/dynamicdoc/DocSets.xml");
                testDocSets = XmlReader.GetOject<DocSets>(content);

            }
            return testDocSets;
        }

        public static string ReadOnlineFile(string url)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(url);
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}