using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherA.Class;
using WeatherA.Models;
using WeatherServices;

namespace Weather.Service
{
    internal class WeatherDownload
    {
        private Consume consume = new Consume();
        private Serialization serialization = new Serialization();
        private DbHelper db = new DbHelper();
        DailyData DailyData = new DailyData();

        public void ProcesarDescarga()
        {
            string res = consume.DownloadData();
            DailyData = serialization.DesSerializar(res);
            db.saveWeatherSummary(DailyData);
        }

        public string GetParamValue(string codParam)
        {
            string param = db.getParamValue(codParam);
            return param;
        }
    }

}
