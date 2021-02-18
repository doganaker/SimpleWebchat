using SimpleWebchat.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SimpleWebchat.BLL.Interfaces
{
    public interface IAdminUser<TEntity> where TEntity : AdminUser
    {
        List<TEntity> ListUsers();
        TEntity Find(int id);
        List<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Remove(int id);
    }
}
