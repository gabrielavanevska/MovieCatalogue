using MovieCatalogue.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCatalogue.Domain.DomainModels
{
    public class PersonalMovies : BaseEntity
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public string UserId { get; set; }
        public CatalogueUser User { get; set; }

    }
}
