using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class StudioModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int GameID { get; set; }
        public string GameName { get; set; } // Derived from Game
    }
}
