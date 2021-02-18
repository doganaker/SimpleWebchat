using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebchat.DAL.Models.Entities
{
    class AdminUser : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string ConnectionID { get; set; }
        public bool OnlineStatus { get; set; }
        public bool IsAdmin { get; set; }

        private DateTime _addDate = DateTime.Now;
        public DateTime AddDate
        {
            get
            {
                return _addDate;
            }
            set
            {
                _addDate = value;
            }
        }
    }
}
