using System.IO;
using System.Linq;
using System.Net;

namespace FinancialChat.Services
{
    public class StookRequest
    {
        private static string urlPrefix = "https://stooq.com/q/l/?s=";
        private static string urlSufix = ".us&f=sd2t2ohlcv&h&e=csv";
        private static string response = "{0} quote is ${1} per share";

        public static string makeStookCall(string keyWord)
        {
            var url = urlPrefix + keyWord + urlSufix;
            var quote = HttpGet(url).Split(',')[13];
            return string.Format(response, keyWord, quote);
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
