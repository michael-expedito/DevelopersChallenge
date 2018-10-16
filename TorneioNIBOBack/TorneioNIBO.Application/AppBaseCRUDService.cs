using System;
using System.Collections.Generic;
using TorneioNIBO.Application.Interface;
using TorneioNIBO.Domain;
using TorneioNIBO.Domain.Interfaces.Services;

namespace TorneioNIBO.Application
{
    public class AppBaseCRUDService<TEntity> : IDisposable, IAppBaseCRUDService<TEntity> where TEntity : class
    {
        private readonly IBaseCRUDService<TEntity> _serviceBase;

        public AppBaseCRUDService(IBaseCRUDService<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Save(TEntity obj)
        {
            _serviceBase.Save(obj);
        }

        public TEntity GetById(int? id)
        {
            return _serviceBase.GetById(id);
        }

        public IList<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Delete(TEntity obj)
        {
            _serviceBase.Delete(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

        public IList<Message> GetMessages()
        {
            return _serviceBase.GetMessages();
        }
    }
}
