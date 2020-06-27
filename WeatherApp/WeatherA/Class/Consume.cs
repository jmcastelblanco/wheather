using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using WeatherA.Models;

namespace WeatherA.Class
{
    public class Consume
    {
        private DbHelper db = new DbHelper();

        public string DownloadData()
        {
            string html = string.Empty;
            string date = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");

            //string url = this.getParamValue("URL7") + "&date=" + "20200207" + "&apiKey=be06c9df19a94dd986c9df19a92dd9ea";
            string url = this.getParamValue("URLHourly") + "&date=" + date + "&apiKey=be06c9df19a94dd986c9df19a92dd9ea";
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            return html;
        }

        public string getParamValue(string codParam)
        {
            string url = db.getParamValue(codParam);
            return url;
        }
    }
}