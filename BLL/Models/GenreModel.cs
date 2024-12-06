using BLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Models
{
    public class GenreModel
    {
        public int ID { get; set; } // Unique identifier for the genre
        public string Name { get; set; } // Name of the genre
        public List<GamesModel> Games { get; set; } = new List<GamesModel>(); // List of games in this genre

        public int GenreID { get; set; }

        public GameGenre Record { get; set; }  // Or the appropriate type
    }
}

