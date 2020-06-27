using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(Weather.Startup))]

namespace Weather
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}