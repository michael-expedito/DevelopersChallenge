using TorneioNIBO.Application.Interface;
using TorneioNIBO.Domain.Entities;
using TorneioNIBO.Domain.Interfaces.Services;

namespace TorneioNIBO.Application
{
    public class MatchAppCRUDService : AppBaseCRUDService<Match>, IMatchAppCRUDService
    {
        public MatchAppCRUDService(IMatchCRUDService serviceBase) : base(serviceBase)
        {
        }
    }
}
