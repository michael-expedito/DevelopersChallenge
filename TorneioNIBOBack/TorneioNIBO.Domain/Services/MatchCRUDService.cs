using TorneioNIBO.Domain.Entities;
using TorneioNIBO.Domain.Interfaces.Repositories;
using TorneioNIBO.Domain.Interfaces.Services;

namespace TorneioNIBO.Domain.Services
{
    public class MatchCRUDService : BaseCRUDService<Match>, IMatchCRUDService
    {
        public MatchCRUDService(IBaseRepository<Match> repository) : base(repository)
        {
        }
    }
}
