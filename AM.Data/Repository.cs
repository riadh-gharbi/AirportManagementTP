using AM.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        readonly AMContext context;

        public Repository(AMContext context)
        {
            this.context = context;
        }

        public void Add(T item)
        {
            context.Add(item);
        }
        public T? Get(int id)
        {
            return context.Find(typeof(T), id) as T;
        }

        public T? Get(string id)
        {
            return context.Find<T>(typeof(T), id);
        }

        public IList<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public void Delete(int id)
        {
            context.Remove(id);
        }

        public void Update(T item)
        {
            context.Update(item);
        }

    }
}
