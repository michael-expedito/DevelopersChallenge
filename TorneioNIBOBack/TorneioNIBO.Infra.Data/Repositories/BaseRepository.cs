using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using TorneioNIBO.Domain.Interfaces.Repositories;
using TorneioNIBO.Infra.Data.Database;

namespace TorneioNIBO.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        //protected ProjetoModeloContext Db = new ProjetoModeloContext();

        protected readonly ISession session = FluentSessionFactory.OpenSession();

        public TEntity FindByObject(TEntity filterObject)
        {
            return null;  /*(from o in session.Query<TEntity>()
                    where o == filterObject
                    select o).FirstOrDefault();*/
        }

        public TEntity FindByPrimaryKey(object id)
        {
            return session.Get<TEntity>(id);
        }

        public TEntity FindEqual(string propertyName, object value)
        {
            return session.CreateCriteria(typeof(TEntity))
                .Add(Expression.Eq(propertyName, value)).UniqueResult<TEntity>();
        }

        public IList<TEntity> GetAll()
        {
            return session.CreateCriteria(typeof(TEntity)).List<TEntity>();
        }

        public IList<TEntity> GetAllEqual(string propertyName, object value)
        {
            return session.CreateCriteria(typeof(TEntity))
                .Add(Expression.Eq(propertyName, value)).List<TEntity>();
        }

        public TEntity Save(TEntity entity)
        {
            session.SaveOrUpdate(entity);
            return entity;
        }

        public TEntity Insert(TEntity entity)
        {
            session.Save(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            session.Update(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            session.Delete(entity);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction()
        {
            FluentSessionFactory.Transaction = session.BeginTransaction();
        }

        public void Commit()
        {
            FluentSessionFactory.Transaction.Commit();
        }

        public void Rollback()
        {
            FluentSessionFactory.Transaction.Rollback();
        }

        public void Evict(TEntity entity)
        {
            session.Evict(entity);
        }

        public void Flush()
        {
            session.Flush();
        }
    }
}
