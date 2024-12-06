#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services.Bases;
using BLL.Models;
using BLL.DAL;
using System.Linq;

// Generated from Custom Template.

namespace MVC.Controllers
{
    public class GameGenresController : MvcController
    {
        // Service injections:
        private readonly IService<GameGenre, GenreModel> _gameGenreService;

        /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
        //private readonly IService<{Entity}, {Entity}Model> _{Entity}Service;

        public GameGenresController(
			IService<GameGenre, GenreModel> gameGenreService

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //, Service<{Entity}, {Entity}Model> {Entity}Service
        )
        {
            _gameGenreService = gameGenreService;

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //_{Entity}Service = {Entity}Service;
        }

        // GET: GameGenres
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _gameGenreService.Query().ToList();
            return View(list);
        }

        // GET: GameGenres/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _gameGenreService.Query().SingleOrDefault(q => q.Record != null && q.Record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //ViewBag.{Entity}Ids = new MultiSelectList(_{Entity}Service.Query().ToList(), "Record.Id", "Name");
        }

        // GET: GameGenres/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: GameGenres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GenreModel gameGenre)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _gameGenreService.Create(gameGenre.Record);
                if (result.IsSuccessfull)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = gameGenre.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(gameGenre);
        }

        // GET: GameGenres/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _gameGenreService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: GameGenres/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GenreModel gameGenre)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _gameGenreService.Update(gameGenre.Record);
                if (result.IsSuccessfull)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = gameGenre.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(gameGenre);
        }

        // GET: GameGenres/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _gameGenreService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: GameGenres/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _gameGenreService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
