using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCatalogue.Domain.DomainModels;
using MovieCatalogue.Domain.DTO;
using MovieCatalogue.Service.Interface;

namespace MovieCatalogue.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: Movies
        public IActionResult Index()
        {
           var allMovies = this._movieService.GetAllMovies();
           return View(allMovies);
          
        }

        public IActionResult PersonalMovies()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(userId == null)
            {
                return View(new List<Movie>());
            }

            var personalMovies = this._movieService.GetAllMoviesByUser(userId);
            return View(personalMovies);
        }


        // GET: Movies/Create
        public IActionResult Create()
        {
            var model = _movieService.GetMovieDtoInfo();
            return View(model);
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title,Picture,Link,GenreIds,Actors,Id")] MovieDto movie)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                this._movieService.CreateNewMovie(movie, userId);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = this._movieService.GetDetailsForMovie(id);

            if (movie == null)
            {
                return NotFound();
            }

            var model = this._movieService.GetMovieDto(movie);
           
            return View(model);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Title,Picture,Link,GenreIds,Actors,Id")] MovieDto movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._movieService.UpdeteExistingMovie(movie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

    
        private bool MovieExists(Guid id)
        {
            return this._movieService.GetDetailsForMovie(id) != null;
        }
    }
}
