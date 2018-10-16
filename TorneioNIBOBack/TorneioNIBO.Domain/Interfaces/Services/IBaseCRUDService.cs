using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneioNIBO.Domain.Interfaces.Services
{
    public interface IBaseCRUDService<TEntity> where TEntity : class
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IList<TEntity> GetAll();
        TEntity GetById(int? Id);
        void Dispose();
        IList<Message> GetMessages();

        bool ValidSave(TEntity entity);
        bool ValidUpdate(TEntity entity);
        bool ValidDelete(TEntity entity);
    }
}
