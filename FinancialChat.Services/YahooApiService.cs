using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FinancialChat.Services
{
    public class YahooApiService
    {
        private static string urlPrefix = "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20(%22";
        private static string urlSufix = "%22)&env=store://datatables.org/alltableswithkeys";
        private static string response = "{0} results : {1}";

        public static string makeYahooApiCall(string keyWord)
        {
            var url = urlPrefix + keyWord + urlSufix;
            XmlDocument xdoc = new XmlDocument();
            var quote = HttpGet(url);
            xdoc.LoadXml(quote.Replace("\n", "").Replace("\\",""));
            return string.Format(response, keyWord, xdoc.ChildNodes[2].InnerText);
        }

        private static string HttpGet(string URI)
        {
            WebClient client = new WebClient();

            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            Stream data = client.OpenRead(URI);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return s;
        }
    }
}
