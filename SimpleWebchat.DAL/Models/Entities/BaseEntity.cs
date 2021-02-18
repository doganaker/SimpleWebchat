using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebchat.DAL.Models.Entities
{
    public class BaseEntity
    {
        public int ID { get; set; }

        private bool _isDeleted = false;
        public bool IsDeleted
        {
            get
            {
                return _isDeleted;
            }
            set
            {
                _isDeleted = value;
            }
        }
    }
}
