using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Hubs
{
    public class MessageHub : Hub
    {
        
        public async Task SendMessageAsync(string message)
        {
            #region All
            //await Clients.All.SendAsync("receiveMessage", message);
            #endregion
            #region Caller
            //await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion
            #region Other
            await Clients.Others.SendAsync("receiveMessage", message);
            #endregion
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }
    }
}
