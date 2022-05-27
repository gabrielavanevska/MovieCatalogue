using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCatalogue.Domain.DomainModels
{
    public class MovieGenre : BaseEntity
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }

    }
}
