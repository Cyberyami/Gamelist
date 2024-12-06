using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace BLL.DAL
{
    public class Game
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int GenreID { get; set; }

        public GameGenre Genre { get; set; }

        public List<Studio> Studios { get; set; } = new List<Studio>(); 
    }
}
