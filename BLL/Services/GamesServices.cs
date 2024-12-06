using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BLL.Services
{
    public class GamesServices : ServiceBase, IService<Game, GamesModel>
    {
        public GamesServices(DB db) : base(db) { }

        public ServiceBase Create(Game record)
        {
            try
            {
                _db.Game.Add(record);
                _db.SaveChanges();
                return Success("Game successfully created.");
            }
            catch (Exception ex)
            {
                return Error($"Failed to create game: {ex.Message}");
            }
        }

        public ServiceBase Update(Game record)
        {
            try
            {
                var existingGame = _db.Game.Find(record.ID);
                if (existingGame == null) return Error("Game not found.");

                // Update fields
                existingGame.Name = record.Name;
                existingGame.ReleaseDate = record.ReleaseDate;
                existingGame.GenreID = record.GenreID;

                _db.SaveChanges();
                return Success("Game successfully updated.");
            }
            catch (Exception ex)
            {
                return Error($"Failed to update game: {ex.Message}");
            }
        }

        public ServiceBase Delete(int id)
        {
            try
            {
                var game = _db.Game.Find(id);
                if (game == null) return Error("Game not found.");

                _db.Game.Remove(game);
                _db.SaveChanges();
                return Success("Game successfully deleted.");
            }
            catch (Exception ex)
            {
                return Error($"Failed to delete game: {ex.Message}");
            }
        }

        public IQueryable<GamesModel> Query()
        {
            // Query and map entities to `GamesModel`
            return _db.Game
                .Include(g => g.Genre) // Include Genre relationship
                .Include(g => g.Studios) // Include Studios relationship
                .Select(g => new GamesModel
                {
                    ID = g.ID,
                    Name = g.Name,
                    GenreID = g.GenreID,
                    GenreName = g.Genre.Name,
                    Studios = g.Studios.Select(s => new StudioModel
                    {
                        ID = s.ID,
                        Name = s.Name
                    }).ToList()
                });
        }
    }
}
