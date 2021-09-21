using System;
using System.IO;
using System.Net;
using System.Text;

namespace asp_net_web_mvc_1.Repository
{
    public class ConnectDatabase
    {
        public static string ExecGet(string url)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            //try
            //{
                using (WebResponse res = req.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(res.GetResponseStream()))
                    {
                        return reader.ReadToEnd();
                    }
                }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        public static string ExecPost(string url, string data, string contentType)
        {

            //try
            //{
                var req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";
                req.ContentType = contentType;

                var byteData = Encoding.UTF8.GetBytes(data);
                req.ContentLength = byteData.Length;

                var dataStream = req.GetRequestStream();
                dataStream.Write(byteData, 0, byteData.Length);
                dataStream.Close();

                var res = req.GetResponse();
                
                using (var reader = new StreamReader(res.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            //}
            //catch (WebException ex)
            //{
            //    var reader = new StreamReader(ex.Response.GetResponseStream());
            //    var str = reader.ReadToEnd();
            //    throw;
            //}

        }
    }
}