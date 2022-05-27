using Microsoft.AspNetCore.Mvc.Rendering;
using MovieCatalogue.Domain.DomainModels;
using MovieCatalogue.Domain.DTO;
using MovieCatalogue.Repository.Interface;
using MovieCatalogue.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieCatalogue.Service.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Genre> _genreRepository;
        private readonly IRepository<MovieGenre> _moviegenreRepository;
        private readonly IRepository<PersonalMovies> _personalmovieRepository;
        private readonly IUserRepository _userRepository;


        public MovieService(IRepository<Movie> movieRepository,
                            IRepository<Genre> genreRepository, 
                            IRepository<MovieGenre> moviegenreRepository,
                            IUserRepository userRepository, 
                            IRepository<PersonalMovies> personalmovieRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _moviegenreRepository = moviegenreRepository;
            _userRepository = userRepository;
            _personalmovieRepository = personalmovieRepository;
        }

        public void CreateNewMovie(MovieDto m, string userId)
        {
    
            Movie movie = new Movie
            {
                Id = Guid.NewGuid(),
                Title = m.Title,
                Link = m.Link,
                Picture = m.Picture
            };

            this._movieRepository.Insert(movie);

         
            GenreMovieRelationship(movie, m.GenreIds);

            if (userId != null)
            {
                var user = this._userRepository.Get(userId);

                PersonalMovies personalMovie = new PersonalMovies
                {
                    Id = Guid.NewGuid(),
                    Movie = movie,
                    User = user,
                    MovieId = movie.Id,
                    UserId = user.Id
                };

                this._personalmovieRepository.Insert(personalMovie);

            }

        }


        public List<Movie> GetAllMovies()
        {
            return this._movieRepository.GetAll().ToList();
        }

        public List<Movie> GetAllMoviesByUser(string userId)
        {
            var user = this._userRepository.Get(userId);

            List<PersonalMovies> personalMovies = _personalmovieRepository.GetAll()
                .Where(x => x.UserId == userId).ToList();

            List<Movie> movies = new List<Movie>();

            foreach(var x in personalMovies)
            {
                movies.Add(x.Movie);
            }
           
            return movies;
        }

        public Movie GetDetailsForMovie(Guid? id)
        {
            return this._movieRepository.Get(id);
        }

        public void UpdeteExistingMovie(MovieDto m)
        {
            Movie movie = new Movie
            {
                Id = m.Id,
                Title = m.Title,
                Link = m.Link,
                Picture = m.Picture
            };

            this._movieRepository.Update(movie);

            SaveAllGenres(movie.Id, m.GenreIds);

        }

        public void SaveAllGenres(Guid movieId, List<Guid> genreIds)
        {
            genreIds = genreIds ?? new List<Guid>();

            if(genreIds.Count != 0)
            {
                List<MovieGenre> entities = _moviegenreRepository.GetAll()
                           .Where(x => x.MovieId == movieId).ToList();


                foreach (var x in entities)
                {
                    _moviegenreRepository.Delete(x);
                }

                Movie movie = _movieRepository.Get(movieId);
                GenreMovieRelationship(movie, genreIds);

            }

            
        }

        public MovieDto GetMovieDtoInfo()
        {
            MovieDto movieDto = new MovieDto();

            var genreDtos = _genreRepository.GetAll();

            movieDto.GenresSelectList = new MultiSelectList(genreDtos, "Id", "Name", movieDto.Genres != null ? movieDto.Genres.Select(x => x.Id).ToList() : null);

            return movieDto;

        }

        public MovieDto GetMovieDto(Movie movie)
        {
            MovieDto movieDto = new MovieDto();

            var genreDtos = _genreRepository.GetAll();

            movieDto.GenresSelectList = new MultiSelectList(genreDtos, "Id", "Name", movieDto.Genres != null ? movieDto.Genres.Select(x => x.Id).ToList() : null);
            movieDto.Id = movie.Id;
            movieDto.Picture = movie.Picture;
            movieDto.Title = movie.Title;
            movieDto.Link = movie.Link;

            return movieDto;
        }

        public void GenreMovieRelationship(Movie movie, List<Guid> GenreIds)
        {

            List<Genre> genres = this._genreRepository.GetAllById(GenreIds).ToList();

            foreach (var item in genres)
            {
                MovieGenre movieGenre = new MovieGenre
                {
                    Id = Guid.NewGuid(),
                    Genre = item,
                    GenreId = item.Id,
                    Movie = movie,
                    MovieId = movie.Id
                };

                this._moviegenreRepository.Insert(movieGenre);

            }

        }



    }
}

