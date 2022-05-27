using Microsoft.AspNetCore.Identity;
using MovieCatalogue.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCatalogue.Domain.Identity
{
    public class CatalogueUser : IdentityUser
    {

        public virtual ICollection<PersonalMovies> PersonalMovies { get; set; }

    }
}
