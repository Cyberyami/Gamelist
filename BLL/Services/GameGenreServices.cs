using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BLL.Services
{
    public class GameGenreServices : ServiceBase, IService<GameGenre, GenreModel>
    {
        public GameGenreServices(DB db) : base(db) { }

        // Create a new GameGenre
        public ServiceBase Create(GameGenre record)
        {
            try
            {
                // Check if the genre already exists
                if (_db.GameGenre.Any(g => g.Name == record.Name))
                {
                    return Error("Genre already exists.");
                }

                // Add the new genre to the database
                _db.GameGenre.Add(record);
                _db.SaveChanges();
                return Success("Genre successfully created.");
            }
            catch (Exception ex)
            {
                return Error($"Failed to create genre: {ex.Message}");
            }
        }

        // Update an existing GameGenre
        public ServiceBase Update(GameGenre record)
        {
            try
            {
                var existingGenre = _db.GameGenre.Find(record.Id);
                if (existingGenre == null) return Error("Genre not found.");

                // Update fields
                existingGenre.Name = record.Name;
                existingGenre.GenreID = record.GenreID;

                _db.SaveChanges();
                return Success("Genre successfully updated.");
            }
            catch (Exception ex)
            {
                return Error($"Failed to update genre: {ex.Message}");
            }
        }

        // Delete a GameGenre by ID
        public ServiceBase Delete(int id)
        {
            try
            {
                var genre = _db.GameGenre.Find(id);
                if (genre == null) return Error("Genre not found.");

                _db.GameGenre.Remove(genre);
                _db.SaveChanges();
                return Success("Genre successfully deleted.");
            }
            catch (Exception ex)
            {
                return Error($"Failed to delete genre: {ex.Message}");
            }
        }

        // Query GameGenres and map them to GameGenreModel
        public IQueryable<GenreModel> Query()
        {
            return _db.GameGenre
                .Include(g => g.Games) // Eager load the related Games
                .AsEnumerable() // Switch to LINQ-to-Objects for further processing
                .Select(g => new GenreModel
                {
                    ID = g.Id,
                    Name = g.Name,
                    GenreID = g.GenreID,
                    Games = g.Games.Select(game => new GamesModel
                    {
                        ID = game.ID,
                        Name = game.Name
                    }).ToList() // Perform projection in memory
                }).AsQueryable(); // Convert back to IQueryable if needed
        }

    }
}
