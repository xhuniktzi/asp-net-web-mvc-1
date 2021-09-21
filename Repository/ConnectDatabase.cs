using System;
using System.IO;
using System.Net;

namespace asp_net_web_mvc_1.Repository
{
    public class ConnectDatabase
    {
        public static string ExecGet(string url)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            try
            {
                using (WebResponse res = req.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(res.GetResponseStream()))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
                throw;
            }
        }
    }
}