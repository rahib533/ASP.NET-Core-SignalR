using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Hubs
{
    public class MyHub : Hub
    {
        static List<string> Users = new List<string>();

        public override async Task OnConnectedAsync()
        {
            Users.Add(Context.ConnectionId);
            await Clients.All.SendAsync("userJoined", Users);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            Users.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("userLeft", Users);
        }
    }
}
