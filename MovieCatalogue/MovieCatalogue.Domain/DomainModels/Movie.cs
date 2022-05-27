using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCatalogue.Domain.DomainModels
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Link { get; set; }


        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
        public virtual ICollection<MoviePerson> MoviePeople { get; set; }
        public virtual ICollection<PersonalMovies> PersonalMovies { get; set; }

    }
}
