using SimpleWebchat.BLL.Interfaces;
using SimpleWebchat.DAL.Models.Context;
using SimpleWebchat.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SimpleWebchat.BLL.Repository
{
    public class AdminUserRepository<TEntity> : IAdminUser<TEntity> where TEntity : AdminUser
    {
        private readonly WebchatContext context;
        public AdminUserRepository()
        {
            context = new WebchatContext();
        }

        public void Add(TEntity entity)
        {
            entity.IsDeleted = false;
            entity.AddDate = DateTime.Now;
            context.Set<TEntity>().Add(entity);
        }

        public TEntity Find(int id)
        {
            var entity = context.Set<TEntity>().Find(id);
            return entity;
        }

        public List<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            var entityList = context.Set<TEntity>().Where(q => q.IsDeleted == false).Where(predicate).ToList();
            return entityList;
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = context.Set<TEntity>().Where(q => q.IsDeleted == false).FirstOrDefault(predicate);
            return entity;
        }

        public List<TEntity> ListUsers()
        {
            var entityList = context.Set<TEntity>().Where(q => q.IsDeleted == false).ToList();
            return entityList;
        }

        public void Remove(int id)
        {
            var entity = context.Set<TEntity>().FirstOrDefault(x => x.ID == id);
            entity.IsDeleted = true;
        }
    }
}
