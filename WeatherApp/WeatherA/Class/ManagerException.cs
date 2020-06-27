using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherA.Models;

namespace WeatherA.Class
{
    public class ManagerException
    {
        public void RegistrarError(ReporteError reporteError)
        {
            string a = reporteError.Error;
        }
    }
}