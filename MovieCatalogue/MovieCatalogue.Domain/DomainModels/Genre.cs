using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCatalogue.Domain.DomainModels
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }


        public virtual ICollection<MovieGenre> MovieGenres { get; set; }


    }
}
