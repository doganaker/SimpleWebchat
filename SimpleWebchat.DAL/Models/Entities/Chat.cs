using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebchat.DAL.Models.Entities
{
    class Chat : BaseEntity
    {
        public string CallerID { get; set; }
        public string ClientID { get; set; }
        public string Content { get; set; }

        private string _time = DateTime.Now.ToString("HH:mm");
        public string Time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
            }
        }
    }
}
