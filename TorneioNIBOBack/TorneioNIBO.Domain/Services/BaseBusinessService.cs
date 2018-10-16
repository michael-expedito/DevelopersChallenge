using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorneioNIBO.Domain.Interfaces.Services;

namespace TorneioNIBO.Domain.Services
{
    public class BaseBusinessService : IBaseBusinessService
    {
        protected List<Message> messages;

        public BaseBusinessService()
        {
            messages = new List<Message>();
        }

        public IList<Message> GetMessages()
        {
            return messages;
        }
    }
}
