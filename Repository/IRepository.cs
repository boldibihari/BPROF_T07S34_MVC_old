using System;
using System.Linq;

namespace Repository
{
    public interface IRepository<T> where T : new()
    {
        void Add(T item);
        void Delete(T item);
        void Delete(string id);
        T Read(string id);
        IQueryable<T> Read();
        void Update(string oldid, T newitem);
        void Save();
    }
}