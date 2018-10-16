using TorneioNIBO.Domain.Entities;
using TorneioNIBO.Domain.Interfaces.Repositories;

namespace TorneioNIBO.Infra.Data.Repositories
{
    public class TournamentRepository : BaseRepository<Tournament>, ITournamentRepository
    {
    }
}
