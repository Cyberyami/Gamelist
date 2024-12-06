namespace BLL.DAL
{
    public class GameGenre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GenreID { get; set; }

        public List<Game> Games { get; set; } = new List<Game>();

    }
}