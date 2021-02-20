using SimpleWebchat.BLL.Interfaces;
using SimpleWebchat.DAL.Models.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebchat.BLL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebchatContext _context;

        public UnitOfWork(WebchatContext context)
        {
            _context = context;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
