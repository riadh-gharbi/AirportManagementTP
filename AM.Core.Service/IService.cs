namespace AM.Core.Service
{
    public interface IService<T> where T : class
    {
        void Add(T entity);
        T Get(int id);
        void Upadate(T t);
        void Delete(T t);
        IList<T> GetAll();
    }
}