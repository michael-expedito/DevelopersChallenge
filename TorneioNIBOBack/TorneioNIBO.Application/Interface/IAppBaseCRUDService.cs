using System.Collections.Generic;
using TorneioNIBO.Domain;

namespace TorneioNIBO.Application.Interface
{
    public interface IAppBaseCRUDService<TEntity> where TEntity : class
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IList<TEntity> GetAll();
        TEntity GetById(int? Id);
        void Dispose();
        IList<Message> GetMessages();
    }
}
