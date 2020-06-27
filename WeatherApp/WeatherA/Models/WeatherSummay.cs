using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherA.Models
{
    public class WeatherSummary
    {
        [Key]
        public int WeatherSummaryID { get; set; }

        //public string stationID { get; set; }
        //public double lat { get; set; }
        //public double lon { get; set; }
        public DateTime obsTimeUtc { get; set; }

        public int humidityHigh { get; set; }
        public int humidityLow { get; set; }
        public int humidityAvg { get; set; }

        //public int qcStatus { get; set; }
    }
}