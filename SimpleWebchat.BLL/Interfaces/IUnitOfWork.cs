using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebchat.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}
