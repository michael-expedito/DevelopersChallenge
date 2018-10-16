using System.Collections.Generic;
using TorneioNIBO.Domain;
using TorneioNIBO.Domain.Interfaces.Services;

namespace TorneioNIBO.Application.Interface
{
    public interface IAppBaseBusinessService<TService> where TService : IBaseBusinessService
    {
        IList<Message> GetMessages();
    }
}
