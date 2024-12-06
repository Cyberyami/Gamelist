using BLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Bases
{
    public abstract class ServiceBase
    {
        public bool IsSuccessfull { get; set; }

        public string Message { get; set; } = string.Empty;

        protected readonly DB _db;


        public ServiceBase(DB db)
        {
            _db = db;
        }

        public ServiceBase Success(string message = "")
        {
            IsSuccessfull = true;
            Message = message;
            return this;
        }
        public ServiceBase Error(string message = "")
        {
            IsSuccessfull = false;
            Message = message;
            return this;
        }
    }
}
