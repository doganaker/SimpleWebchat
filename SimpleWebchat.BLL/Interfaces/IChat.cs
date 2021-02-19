using SimpleWebchat.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebchat.BLL.Interfaces
{
    public interface IChat<TEntity> where TEntity : Chat
    {
        List<TEntity> GetChat(int callerId, int clientId);
    }
}
