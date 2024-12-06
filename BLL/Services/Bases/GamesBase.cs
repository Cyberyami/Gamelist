using BLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Bases
{
    public abstract class GamesBase
    {
        public bool IsSuccesfull { get; set; }

        public string Message { get; set; } = string.Empty;

        protected readonly DB _db;


        public GamesBase(DB db)
        {
            _db = db;
        }

        public GamesBase Success(string message = "") {
            IsSuccesfull = true;
            Message = message; 
            return this;
        }
        public GamesBase Error(string message = "")
        {
            IsSuccesfull = false;
            Message = message;
            return this;
        }
    }
}
