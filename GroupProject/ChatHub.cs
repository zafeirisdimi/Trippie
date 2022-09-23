using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace GroupProject
{
    public class ChatHub : Hub
    {
        private static string adminUserId;
        private static string adminConnectionId;
        private Dictionary<string, string> userIds;

        //public void AddUserToMainGroup(string id, string role)
        //{
        //    if (role == "admin")
        //    {
        //        adminUserId = id;
        //        adminConnectionId = Context.ConnectionId;
        //    }
            

        //    Groups.Add(Context.ConnectionId, "main");
        //}

        public void RegisterAdminInfo(string id, string role)
        {
            if (role == "admin")
            {
                adminUserId = id;
                adminConnectionId = Context.ConnectionId;
            }
            //Clients.All.Client(adminConnectionId).notifyAdmin(adminConnectionId);
        }

        public async Task CreateUserPrivateChat(string userId)
        {
            string groupname = userId;

            await Groups.Add(Context.ConnectionId, groupname);
            await Groups.Add(adminConnectionId, groupname);

            Clients.Group(groupname).notify(groupname);
        }

        public void SendPrivate(string groupname, string name, string message, string roleTest)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.Group(groupname).addPrivateMessage(groupname, name, message, roleTest);
        }


        //public void Send(string name, string message, string roleTest)
        //{
        //    // Call the addNewMessageToPage method to update clients.
        //    Clients.All.addNewMessageToPage(name, message, roleTest);
        //}

    }
}