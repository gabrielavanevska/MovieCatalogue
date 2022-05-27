using MovieCatalogue.Domain.DomainModels;
using MovieCatalogue.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCatalogue.Service.Interface
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();
        List<Movie> GetAllMoviesByUser(string userId);
        Movie GetDetailsForMovie(Guid? id);
        void CreateNewMovie(MovieDto m, string userId);
        void UpdeteExistingMovie(MovieDto m);
        MovieDto GetMovieDtoInfo();
        MovieDto GetMovieDto(Movie movie);

    }
}
