using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class DB : DbContext
    {
        public DbSet<Game> Game {  get; set; }
        public DbSet<GameGenre> GameGenre { get; set; }
        public DbSet<Studio> Studio { get; set; }

        public DB(DbContextOptions options) : base(options)
        {
        }

    }
}
