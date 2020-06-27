using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherA.Class
{
    public class MessagesView
    {
        public string obsTimeUtc { get; set; }
        public int humidityHigh { get; set; }
        public int humidityLow { get; set; }
        public int humidityAvg { get; set; }
    }
}