using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using McMovies.Models;
using System.Xml.Linq;
using System;
using System.Collections.Generic;

namespace McMovies.Controllers
{
    public class McMoviesController : Controller
    {
        private ApplicationDbContext _context;

        public McMoviesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: McMovies
        public IActionResult Index(string movieActor, string SearchString)
        {
            var ActorQry = from m in _context.McMovie
                           orderby m.Cast
                           select m.Cast;

            var ActorList = new List<string>();
            ActorList.AddRange(ActorQry.Distinct());
            ViewData["movieActor"] = new SelectList(ActorList);

            var movies = from m in _context.McMovie
                         select m;

            if (!String.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!String.IsNullOrEmpty(movieActor))
            {
                movies = movies.Where(x => x.Cast == movieActor);
            }

            return View(movies);
        }

        // GET: McMovies/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            McMovie movie = _context.McMovie.Single(m => m.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // GET: McMovies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: McMovies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            [Bind("ID,Title,ReleaseDate,Cast,RunTime,Review,Rating")]McMovie movie)
        {
            if (ModelState.IsValid)
            {
                _context.McMovie.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: McMovies/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            McMovie movie = _context.McMovie.Single(m => m.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: McMovies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(
            [Bind("ID,Title,ReleaseDate,Cast,RunTime,Review,Rating")]McMovie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: McMovies/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            McMovie movie = _context.McMovie.Single(m => m.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // POST: McMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(
            [Bind("ID,Title,ReleaseDate,Cast,RunTime,Review")]int id)
        {
            McMovie movie = _context.McMovie.Single(m => m.ID == id);
            _context.McMovie.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
