using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IGamesService
    {
        GamesBase Create(Game record);
        GamesBase Update(Game record);
        GamesBase Delete(int id);
        IQueryable<GamesModel> Query();
    }
}
