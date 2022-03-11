using System.Collections.Generic;

namespace Bills_System.Repository
{
    public interface IRepository<T>
    {
        int Add(T newT);
        int Delete(int id);
        List<T> GetAll();
        T GetById(int id);
        int Update(int id, T newT);
    }
}
