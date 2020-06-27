using WeatherA.Models;
using Newtonsoft.Json;

namespace WeatherServices
{
    public class Serialization
    {
        public DailyData DesSerializar(string json)
        {
            DailyData data = new DailyData();
            data = JsonConvert.DeserializeObject<DailyData>(json);
            return data;
        }
    }
}