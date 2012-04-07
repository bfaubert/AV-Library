using System.Linq;
using Core.Infrastructure.Repositories.Queries;

namespace Core.Domain.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T LoadById(int id);
        T GetOne(QueryBase<T> query);
        IQueryable<T> GetList(QueryBase<T> query);
        void SaveOrUpdate(T model);
    }
}