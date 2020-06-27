using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WeatherA.Class
{
    class DbListener
    {
        public DbListener()
        {
            string _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Debug.WriteLine(_connString);

            SqlDependency.Stop(_connString);
            SqlDependency.Start(_connString);
            connection = new SqlConnection(_connString);
            connection.Open();
            SomeMethod();
        }
        SqlConnection connection;
        void SomeMethod()
        {
            // Assume connection is an open SqlConnection.
            // Create a new SqlCommand object.

            SqlCommand command = new SqlCommand("SELECT obsTimeUtc,humidityHigh,humidityLow,humidityAvg FROM [WeatherA_DB].[dbo].[WeatherSummaries]", connection);
            // Create a dependency and associate it with the SqlCommand.
            command.Notification = null;  // ---> DO I NEED IT??
            SqlDependency dependency = new SqlDependency(command);
            // Maintain the refence in a class member.
            // Subscribe to the SqlDependency event.
            dependency.OnChange += new OnChangeEventHandler(OnDependencyChange);
            // Execute the command.
            command.ExecuteReader();
        }
        // Handler method
        void OnDependencyChange(object sender, SqlNotificationEventArgs e)
        {
            // Handle the event (for example, invalidate this cache entry).
            Debug.WriteLine("BAse de datos cambiando");
            SomeMethod();
        }

        void Termination()
        {
            // Release the dependency.
            SqlDependency.Stop(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
    }
}