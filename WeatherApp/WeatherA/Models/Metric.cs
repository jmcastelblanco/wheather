using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherA.Models
{
    public class Metric
    {
        public int tempHigh { get; set; }
        public int tempLow { get; set; }
        public int tempAvg { get; set; }
        public int windspeedHigh { get; set; }
        public int windspeedLow { get; set; }
        public int windspeedAvg { get; set; }
        public int windgustHigh { get; set; }
        public int windgustLow { get; set; }
        public int windgustAvg { get; set; }
        public int dewptHigh { get; set; }
        public int dewptLow { get; set; }
        public int dewptAvg { get; set; }
        public int windchillHigh { get; set; }
        public int windchillLow { get; set; }
        public int windchillAvg { get; set; }
        public int heatindexHigh { get; set; }
        public int heatindexLow { get; set; }
        public int heatindexAvg { get; set; }
        public double pressureMax { get; set; }
        public double pressureMin { get; set; }
        public double pressureTrend { get; set; }
        public double precipRate { get; set; }
        public double precipTotal { get; set; }
    }

}