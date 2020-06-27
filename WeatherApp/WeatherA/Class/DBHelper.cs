using WeatherA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherA.Class;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Configuration;

namespace WeatherA.Class
{
    

    public class DbHelper
    {
        private WeatherAContext dbase = new WeatherAContext();
        readonly string _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static Response Save(WeatherAContext db)
        {
            try
            {
                db.SaveChanges();
                Hubs.MessagesHub.SendMessages();
                return new Response { Succeeded = true, };
            }
            catch (Exception ex)
            {
                var respuesta = new Response { Succeeded = false, };
                if (ex.InnerException != null &&
                    ex.InnerException.InnerException != null)
                {
                    if (ex.InnerException.InnerException.Message.Contains("_Index"))
                    {
                        respuesta.Message = "¡Error! el registro ya existe";
                        if (ex.InnerException.InnerException.Message.Contains("Referencia_Index"))
                        {
                            respuesta.Message = "¡Error! código ya existe";
                        }
                        if (ex.InnerException.InnerException.Message.Contains("Name_Index"))
                        {
                            respuesta.Message = "¡Error! el Nombre ya existe";
                        }
                    }
                    if (ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                    {
                        respuesta.Message = "¡Error! no se puede eliminar. Tiene registros relacionados";
                    }

                }
                else
                {
                    respuesta.Message = ex.Message;
                }
                new ManagerException().RegistrarError(new ReporteError { Fecha = DateTime.Now, Error = ex.Message, Traza = ex.ToString(), Origen = "AppWEb", Referencia = "Consulta DB" });
                return respuesta;
            }
        }

        public void saveWeatherSummary(DailyData dailyData)
        {
            WeatherSummary weatherSummary = new WeatherSummary();
            int humidityAvg = 0;
            int humidityHigh = 0;
            int humidityLow = 0;
            int cont = 0;
            DateTime date = DateTime.MinValue;
            foreach (Observation item in dailyData.observations)
            {
                humidityAvg = humidityAvg + item.humidityHigh;
                humidityHigh = humidityHigh + item.humidityHigh;
                humidityLow = humidityLow + item.humidityLow;
                date = item.obsTimeUtc;
                cont++;
            }
            weatherSummary.humidityAvg = humidityAvg / cont;
            weatherSummary.humidityHigh = humidityHigh / cont;
            weatherSummary.humidityLow = humidityLow / cont;
            weatherSummary.obsTimeUtc = date;
            dbase.WeatherSummaries.Add(weatherSummary);
            Response res = new Response();
            res = DbHelper.Save(dbase);
        }

        /*internal string getParamValues(string v)
        {
            string param;
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT Session_logID, UserID, Date, Entry,Photo,Commentaries FROM dbo.Session_log", connection))

                {
                    command.Notification = null;
                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        
                        //E.Descripcion as Estado, M.Nombre as Nombre, Fecha,Comentarios
                        if (reader["Commentaries"].ToString().Length < 1)
                        {
                            param = "";
                        }
                        else
                        {
                            param = (string)reader["Commentaries"];
                        }
                        string cid = (int)reader["UserID"];

                    }
                    return param;
                }
            }
        }
        */

        public string getParamValue(string codParam)
        {
            string param = dbase.Parameters.Where(es => es.CodParam == codParam).FirstOrDefault().Value1;
            return param;
        }

        public static int GetEstado(string descripcion, WeatherAContext db)
        {
            var estado = db.States.Where(e => e.Name == descripcion).FirstOrDefault();
            if (estado == null)
            {
                estado = new State { Name = descripcion, };
                db.States.Add(estado);
                db.SaveChanges();
            }
            return estado.StateID;
        }
    }
}