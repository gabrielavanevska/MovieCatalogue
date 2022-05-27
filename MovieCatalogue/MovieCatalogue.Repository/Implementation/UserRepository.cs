using Microsoft.EntityFrameworkCore;
using MovieCatalogue.Domain.Identity;
using MovieCatalogue.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieCatalogue.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<CatalogueUser> entities;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<CatalogueUser>();
        }
        public IEnumerable<CatalogueUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public CatalogueUser Get(string id)
        {
            return entities
               .Include(z => z.PersonalMovies)
               .Include("PersonalMovies.Movie")
               .SingleOrDefault(s => s.Id == id);
        }
        public void Insert(CatalogueUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(CatalogueUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

    }
}
