using Microsoft.EntityFrameworkCore;
using SimpleWebchat.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebchat.DAL.Models.Context
{
    public class WebchatContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=localhost\SQLEXPRESS;database=WebchatDB;trusted_connection=true;");
        }

        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Chat> Chats { get; set; }
    }
}
