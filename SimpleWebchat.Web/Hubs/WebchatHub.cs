using Microsoft.AspNetCore.SignalR;
using SimpleWebchat.BLL.Interfaces;
using SimpleWebchat.BLL.Repository;
using SimpleWebchat.BLL.UnitOfWork;
using SimpleWebchat.DAL.Models.Context;
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
        //private IUnitOfWork _unitOfWork;
        private IChat<Chat> _chat;
        private WebchatContext _context;

        public override Task OnConnectedAsync()
        {
            _context = new WebchatContext();

            var email = Context.User.Claims.ToArray()[0].Value;

            _adminUser = new AdminUserRepository<AdminUser>();

            var user = _adminUser.FirstOrDefault(q => q.EMail == email);

            user.ConnectionID = Context.ConnectionId;
            user.OnlineStatus = true;

            //_unitOfWork = new UnitOfWork(_context);
            //_unitOfWork.SaveChanges();
            
            _context.SaveChanges();

            string connectedUID = Context.User.Claims.ToArray()[1].Value;

            Clients.All.SendAsync("ActiveUser", connectedUID);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _context = new WebchatContext();
            _adminUser = new AdminUserRepository<AdminUser>();

            var email = Context.User.Claims.ToArray()[0].Value;

            var user = _adminUser.FirstOrDefault(q => q.EMail == email);

            user.OnlineStatus = false;

            //_unitOfWork = new UnitOfWork(_context);
            //_unitOfWork.SaveChanges();

            _context.SaveChanges();

            string connectedUID = Context.User.Claims.ToArray()[1].Value;

            Clients.All.SendAsync("InactiveUser", connectedUID);

            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string id, string connectionid, string message)
        {
            string msg = message;
            int clientId = Convert.ToInt32(id);
            int callerId = Convert.ToInt32(Context.User.Claims.ToArray()[1].Value);
            string userCid = Context.ConnectionId;

            await Clients.Caller.SendAsync("ReceiveMessage", userCid, msg);
            await Clients.Client(connectionid).SendAsync("RecieveMessage", userCid, msg);

            Chat text = new Chat();
            text.Content = msg;
            text.CallerID = callerId;
            text.ClientID = clientId;

            _context = new WebchatContext();
            _chat = new ChatRepository<Chat>();
            //_unitOfWork = new UnitOfWork(_context);

            _chat.Add(text);
            _context.SaveChanges();

            //_unitOfWork.SaveChanges();

        }
    }
}
