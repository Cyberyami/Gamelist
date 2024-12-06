using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Studio
    {

        public int ID {  get; set; }
        [Required]
        public string Name { get; set; }

        public int? GameID { get; set; }

        public Game Game { get; set; }
    }
}
