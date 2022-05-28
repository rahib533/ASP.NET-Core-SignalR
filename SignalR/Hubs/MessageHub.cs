using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Hubs
{
    public class MessageHub : Hub
    {
        
        public async Task SendMessageAsync2(string message, IEnumerable<string>connectionIds)
        {
            #region All
            //await Clients.All.SendAsync("receiveMessage", message);
            #endregion
            #region Caller
            //await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion
            #region Other
            //await Clients.Others.SendAsync("receiveMessage", message);
            #endregion
            #region AllExcept
            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Client
            //await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message);
            #endregion
            #region Clients
            await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);
            #endregion
        }

        public async Task SendMessageAsync(string message, string groupName)
        {
            #region Group
            await Clients.Group(groupName).SendAsync("receiveMessage", message);
            #endregion
        }
        public async Task AddGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }
    }
}
