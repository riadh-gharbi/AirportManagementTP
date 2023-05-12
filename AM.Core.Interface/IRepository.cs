namespace AM.Core.Interface
{
    public interface IRepository<T> where T : class
    {
        void Add(T t);
        T Get(int id);
        T Get(string id);
        void Update(T t);
        void Delete(T t);
        IList<T> GetAll();
    }
}