using TorneioNIBO.Application.Interface;
using TorneioNIBO.Domain.Entities;
using TorneioNIBO.Domain.Interfaces.Services;

namespace TorneioNIBO.Application
{
    public class TournamentAppCRUDService : AppBaseCRUDService<Tournament>, ITournamentAppCRUDService
    {
        public TournamentAppCRUDService(ITournamentCRUDService serviceBase) : base(serviceBase)
        {
        }
    }
}
