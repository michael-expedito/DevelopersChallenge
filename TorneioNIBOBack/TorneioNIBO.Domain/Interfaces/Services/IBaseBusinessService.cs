using System.Collections.Generic;

namespace TorneioNIBO.Domain.Interfaces.Services
{
    public interface IBaseBusinessService
    {
        IList<Message> GetMessages();
    }
}
