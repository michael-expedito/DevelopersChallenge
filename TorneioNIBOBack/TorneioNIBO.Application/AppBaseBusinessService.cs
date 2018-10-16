using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorneioNIBO.Application.Interface;
using TorneioNIBO.Domain;
using TorneioNIBO.Domain.Interfaces.Services;

namespace TorneioNIBO.Application
{
    public class AppBaseBusinessService<TService> : IAppBaseBusinessService<TService> where TService : IBaseBusinessService
    {
        protected TService _serviceBusinessBase;

        public AppBaseBusinessService(TService serviceBase)
        {
            this._serviceBusinessBase = serviceBase;
        }

        public IList<Message> GetMessages()
        {
            return this._serviceBusinessBase.GetMessages();
        }
    }
}
