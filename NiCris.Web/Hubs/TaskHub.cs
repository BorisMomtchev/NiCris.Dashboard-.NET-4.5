using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NiCris.Web.Hubs
{
    public class TaskHub : Hub
    {
        public void SendMessage(string clientName, string message)
        {
            Clients.GetMessage(clientName, message);
        }
    }
}