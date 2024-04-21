using Core.Utility.Spiders;
using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Linq;

namespace Core.Web.Utility
{
    public class Soap
    {
        public static string Request(string url, string xml)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var request = (HttpWebRequest)System.Net.WebRequest.Create(url);
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";
            request.Method = "POST";

            var soapRequestBody = new XmlDocument();
            soapRequestBody.LoadXml(xml);

            using (var stream = request.GetRequestStream())
            {
                soapRequestBody.Save(stream);
            }
 
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (var rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    return rd.ReadToEnd();
                }
            }
        }

        public static void Request(string url, string xml, Action<XDocument> aXd)
        {
            var result = Request(url, xml);
            var xd = XDocument.Parse(result);
            aXd(xd);
        }

        public static T Request<T>(string url, string xml, Func<XDocument, T> aXd)
        {
            var result = Request(url, xml);
            var xd = XDocument.Parse(result);
            return aXd(xd);
        }
    }
}