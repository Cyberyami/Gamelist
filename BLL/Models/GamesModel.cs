using BLL.DAL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GamesModel
{
    public int ID { get; set; }
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }  // Ensure this is spelled correctly
    public int GenreID { get; set; }
    public string GenreName { get; set; }
    public List<StudioModel> Studios { get; set; }

    // If 'Record' is supposed to be a different entity, it should be defined here as well
    public Game Record { get; set; }  // Or the appropriate type
}
