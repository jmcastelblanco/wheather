using WeatherA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WeatherA.Class
{
    public class InstallHelper : IDisposable
    {
        private static WeatherAContext db = new WeatherAContext();

        public static void InitialConfiguration()
        {
            AddParameters();
            insSuperadmin();
        }
        public static void AddParameters()
        {
            var consulta = db.Parameters.Count();
            if (consulta < 1)
            {
                insParameter("apiKey"
                    , "be06c9df19a94dd986c9df19a92dd9ea"
                    , "API Key");
                insParameter("URL7"
                    , "https://api.weather.com/v2/pws/dailysummary/7day?stationId=KMAHANOV10&format=json&units=e&"
                    , "URL para mostrar los 7 ultimos dias de la fecha actual");
                insParameter("URLHourly"
                    , "https://api.weather.com/v2/pws/history/hourly?stationId=KCAOAKLA44&format=json&units=m"
                    , "URL para mostrar las ultimas 24 horas de la fecha puesta");
                insParameter("TimeInterval"
                    , "2"
                    , "Tiempo en minutos para el intervalo en que se ejecuta el servicio windows");
                db.SaveChanges();
            }
        }
        public static void insParameter(string codParam, string value, string description)
        {
            var parameter = new Parameters
            {
                CodParam = codParam,
                Value1 = value,
                Description = description,
            };
            db.Parameters.Add(parameter);
            db.SaveChanges();
        }
        public static void InsRol(String rolName)
        {
            var rol = new Rol
            {
                Name = rolName,
            };
            db.Roles.Add(rol);
            db.SaveChanges();
        }
        public static void insSuperadmin()
        {
            var empresaCount = db.Roles.Count();
            if (empresaCount < 1)
            {

                InsRol("SuperAdmin");
                InsRol("Admin");
            }
            empresaCount = db.Users.Count();
            if (empresaCount < 1)
            {
                var user = new User
                {
                    FirstName = "Pablo",
                    SecondName = "Andrés",
                    Phone = "3122683980",
                    Address = "Unknown",
                    CountryID=1,
                    DocumentTypeID=1,
                    DocumentNumber="13088512",
                    DepartmentID = 21,
                    CityID = 801,
                    LastName = "Gómez",
                    RolID = 1,
                    UserName = "soidneo@gmail.com",
                    password ="123456",
                    
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}