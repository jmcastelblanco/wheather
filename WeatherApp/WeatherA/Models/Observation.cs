using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherA.Models
{
    public class Observation
    {
        public string stationID { get; set; } 
        public string tz { get; set; }
        public DateTime obsTimeUtc { get; set; }
        public string obsTimeLocal { get; set; }
        public int epoch { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public object solarRadiationHigh { get; set; }
        public object uvHigh { get; set; }
        public int winddirAvg { get; set; }
        public int humidityHigh { get; set; }
        public int humidityLow { get; set; }
        public int humidityAvg { get; set; }
        public int qcStatus { get; set; }
        public Metric metric { get; set; }
    }
}