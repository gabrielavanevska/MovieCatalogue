using MovieCatalogue.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCatalogue.Repository.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllById(List<Guid> GenreIds);
        T Get(Guid? id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
