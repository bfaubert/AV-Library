using System.Linq;
using Core.Domain.Interfaces;
using Core.Infrastructure.Repositories.Queries;
using NHibernate;
using NHibernate.Linq;

namespace Core.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public IQueryable<T> GetAll()
        {
            //using (Session)
            //using (Session.BeginTransaction())
            //{
            return _session.Query<T>();
            //}
        }

        public T GetById(int id)
        {
            return _session.Get<T>(id);
        }

        public T LoadById(int id)
        {
            return _session.Load<T>(id);
        }

        public T GetOne(QueryBase<T> query)
        {
            return query.SatisfyingElementFrom(GetAll());
        }

        public IQueryable<T> GetList(QueryBase<T> query)
        {
            //using(Session)
            //using (Session.BeginTransaction())
            //{
            return query.SatisfyingElementsFrom(GetAll()); //Session.Query<T>().Where(expression);
            //}
        }

        public void SaveOrUpdate(T model)
        {
            using (var tx = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(model);
                tx.Commit();
            }
        }
    }
}