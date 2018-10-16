using System.Collections.Generic;
using TorneioNIBO.Domain;

namespace TorneioNIBO.API.Models
{
    public class Response<T>
    {
        public T data { get; set; }
        public IList<Message> messages { get; set; }
    }
}