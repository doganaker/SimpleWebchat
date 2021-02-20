using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebchat.DAL.Models.Entities
{
    public class Chat : BaseEntity
    {
        public int CallerID { get; set; }
        public int ClientID { get; set; }
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
