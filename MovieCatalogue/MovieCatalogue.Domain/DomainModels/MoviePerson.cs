using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCatalogue.Domain.DomainModels
{
    public class MoviePerson : BaseEntity
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }

    }
}
