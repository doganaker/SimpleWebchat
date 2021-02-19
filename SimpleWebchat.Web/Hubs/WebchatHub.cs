using Microsoft.AspNetCore.SignalR;
using SimpleWebchat.BLL.Interfaces;
using SimpleWebchat.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebchat.Web.Hubs
{
    public class WebchatHub : Hub
    {
        private IAdminUser<AdminUser> _adminUser;
        private IUnitOfWork _unitOfWork;

        public override Task OnConnectedAsync()
        {
            var email = Context.User.Claims.ToArray()[0].Value;

            var user = _adminUser.FirstOrDefault(q => q.EMail == email);

            user.ConnectionID = Context.ConnectionId;
            user.OnlineStatus = true;

            _unitOfWork.SaveChanges();

            string connectedUID = Context.User.Claims.ToArray()[1].Value;

            Clients.All.SendAsync("ActiveUser", connectedUID);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var email = Context.User.Claims.ToArray()[0].Value;

            var user = _adminUser.FirstOrDefault(q => q.EMail == email);

            user.OnlineStatus = false;

            _unitOfWork.SaveChanges();

            string connectedUID = Context.User.Claims.ToArray()[1].Value;

            Clients.All.SendAsync("InactiveUser", connectedUID);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
