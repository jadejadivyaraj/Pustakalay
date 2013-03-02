using System.Collections.Generic;

namespace Pustakalay.Infrastructure
{
    public interface IRepository<T>
    {
        void CreateRepository();
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
    }
}
