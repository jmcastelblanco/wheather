using WeatherA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WeatherA.Class
{
    public class AlertsHelper
    {
        private WeatherAContext db = new WeatherAContext();
        readonly string _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<MessagesView> GetAllMessages()
        {
            var messagesView = new List<MessagesView>();
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT obsTimeUtc,humidityHigh,humidityLow,humidityAvg FROM [dbo].[WeatherSummaries]", connection))

                {
                    command.Notification = null;
                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        messagesView.Add(item: new MessagesView
                        {
                            obsTimeUtc = reader["obsTimeUtc"].ToString(),
                            humidityAvg = Int32.Parse(reader["humidityAvg"].ToString()),
                            humidityHigh = Int32.Parse(reader["humidityHigh"].ToString()),
                            humidityLow = Int32.Parse(reader["humidityLow"].ToString()),
                        });
                    }
                }
            }
            var newList = messagesView.OrderByDescending(c => c.obsTimeUtc).ToList();
            return newList;
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            //if (e.Type == SqlNotificationType.Change)
            //{
            //    Hubs.MessagesHub.SendMessages();
            //}
            
            SqlDependency dependency =
             (SqlDependency)sender;
            dependency.OnChange -= dependency_OnChange;
            Hubs.MessagesHub.SendMessages(); //re-regist
        }
    }
}