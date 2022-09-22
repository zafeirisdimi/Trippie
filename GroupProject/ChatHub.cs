using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProject
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message, string roleTest)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message, roleTest);
        }


        public void Hello()
        {
            Clients.All.hello();
        }
    }
}