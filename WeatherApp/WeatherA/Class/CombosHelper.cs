using WeatherA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherA.Class
{
    public class CombosHelper : IDisposable
    {
        private static WeatherAContext db = new WeatherAContext();
        
        public static List<Rol> GetRoles()
        {
            var roles = db.Roles.ToList();
            roles.Add(new Rol
            {
                RolID = 0,
                Name = "[Seleccione un Rol...]"
            });
            return roles.OrderBy(d => d.Name).ToList();
        }
        
        public void Dispose()
        {
            db.Dispose();
        }
    }
}