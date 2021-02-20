using SimpleWebchat.BLL.Interfaces;
using SimpleWebchat.DAL.Models.Context;
using SimpleWebchat.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWebchat.BLL.Repository
{
    public class ChatRepository<TEntity> : IChat<TEntity> where TEntity : Chat
    {
        private readonly WebchatContext context;

        public ChatRepository()
        {
            context = new WebchatContext();
        }

        public void Add(TEntity entity)
        {
            entity.IsDeleted = false;
            entity.Time = DateTime.Now.ToString("HH:mm");
            context.Set<TEntity>().Add(entity);
        }

        List<TEntity> IChat<TEntity>.GetChat(int callerId, int clientId)
        {
            var history = context.Set<TEntity>().Where(q => (q.CallerID == callerId && q.ClientID == clientId) || (q.CallerID == clientId && q.ClientID == callerId)).ToList();

            return history;
        }
    }
}
