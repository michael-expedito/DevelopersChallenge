using System;
using System.Collections.Generic;
using TorneioNIBO.Domain.Interfaces.Repositories;
using TorneioNIBO.Domain.Interfaces.Services;

namespace TorneioNIBO.Domain.Services
{
    public class BaseCRUDService<TEntity> : IBaseCRUDService<TEntity> where TEntity : class
    {
        protected readonly IBaseRepository<TEntity> _repository;

        protected IList<Message> messages;

        public BaseCRUDService(IBaseRepository<TEntity> repository)
        {
            this._repository = repository;
            messages = new List<Message>();
        }

        public virtual void Delete(TEntity entity)
        {
            try
            {
                if (ValidDelete(entity))
                {
                    _repository.BeginTransaction();
                    _repository.Delete(entity);
                    _repository.Commit();
                    messages.Add(new Message("FW01", MessageType.success, "Registro excluído com sucesso!"));
                }
            }
            catch (Exception e)
            {
                _repository.Rollback();
                messages.Add(new Message("FW02", MessageType.error, "Erro ao excluir o registro! erro:" + e.Message));
            }

        }

        public virtual void Save(TEntity entity)
        {
            try
            {
                if (ValidSave(entity))
                {
                    _repository.BeginTransaction();
                    _repository.Save(entity);
                    _repository.Commit();
                    messages.Add(new Message("FW03", MessageType.success, "Registro salvo com sucesso!"));
                }
            }
            catch (Exception e)
            {
                _repository.Rollback();
                messages.Add(new Message("FW04", MessageType.error, "Erro ao salvar o registro! erro:" + e.Message));
            }
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                if (ValidUpdate(entity))
                { 
                    _repository.BeginTransaction();
                    _repository.Update(entity);
                    _repository.Commit();
                    messages.Add(new Message("FW05", MessageType.success, "Registro atualizado com sucesso!"));
                }
            }
            catch (Exception e)
            {
                messages.Add(new Message("FW06", MessageType.error, "Erro ao atualizar o registro! erro:" + e.Message));
                _repository.Rollback();
            }
        }

        public virtual IList<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TEntity GetById(int? Id)
        {
            return _repository.FindByPrimaryKey(Id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IList<Message> GetMessages()
        {
            return messages;
        }

        public virtual bool ValidSave(TEntity entity)
        {
            return true;
        }

        public virtual bool ValidUpdate(TEntity entity)
        {
            return true;
        }

        public virtual bool ValidDelete(TEntity entity)
        {
            return true;
        }

        protected bool HasFatalError()
        {
            foreach (var message in messages)
            {
                if (message.type == MessageType.error)
                    return true;
            }
            return false;
        }
    }
}
