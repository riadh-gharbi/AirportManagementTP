using AM.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Service
{
    public  class Service<T>: IService<T> where T : class
    {
        IRepository<T> repository;
        readonly IUnitOfWork unitOfWork;
        public Service(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
            repository = unitOfWork.GetRepository<T>();
        }

        public void Add(T entity)
        {
            repository.Add(entity);
            unitOfWork.Save();
        }

        public void Delete(T t)
        {
            repository.Delete(t);
            unitOfWork.Save();
        }

        public T Get(int id)
        {
            return repository.Get(id);
        }

        public IList<T> GetAll()
        {
            return repository.GetAll();
        }

        public void Upadate(T t)
        {
            repository.Update(t);
            unitOfWork.Save();
        }
    }
}
