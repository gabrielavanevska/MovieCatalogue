using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCatalogue.Domain.DomainModels
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }


        public virtual ICollection<MoviePerson> MoviePeople { get; set; }
        public virtual ICollection<PersonRole> PersonRoles { get; set; }

    }
}
