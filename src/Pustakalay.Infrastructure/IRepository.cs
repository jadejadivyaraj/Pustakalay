using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
