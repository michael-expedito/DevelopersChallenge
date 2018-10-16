using System.Collections.Generic;

namespace TorneioNIBO.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity FindByObject(TEntity filterObject);
        TEntity FindByPrimaryKey(object id);
        TEntity FindEqual(string propertyName, object value);
        IList<TEntity> GetAll();
        IList<TEntity> GetAllEqual(string propertyName, object value);
        TEntity Save(TEntity entity);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        void Dispose();

        void Evict(TEntity entity);
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
