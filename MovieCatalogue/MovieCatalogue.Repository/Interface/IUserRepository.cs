using MovieCatalogue.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCatalogue.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<CatalogueUser> GetAll();
        CatalogueUser Get(string id);
        void Insert(CatalogueUser entity);
        void Update(CatalogueUser entity);
    }
}
