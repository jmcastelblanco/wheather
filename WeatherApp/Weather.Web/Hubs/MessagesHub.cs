using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;


namespace Weather.Hubs
{
    [HubName("messagesHub")]
    public class MessagesHub : Hub
    {
        public void UpdateInfoWeather()
        {

        }

        private static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        public void Hello()
        {
            Clients.All.hello();
        }

        [HubMethodName("sendMessages")]
        public static void SendMessages()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MessagesHub>();
            Console.WriteLine("yeah of fire");
            context.Clients.All.updateMessages();
        }
    }
}