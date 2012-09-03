using Newtonsoft.Json;
using NiCris.BusinessObjects;
using SignalR;
using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NiCris.Web.Hubs
{
    public class Chat : Hub
    {
        public void Send(string message)
        {
            // Call the addMessage method on all clients
            Clients.addMessage(message);
        }
    }

    public class Notifier
    {
        public static void Send(BizMsgEx bizMsgEx)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<Chat>();
            string json = JsonConvert.SerializeObject(bizMsgEx);
            context.Clients.addMessageEx(json);
        }
    }
}