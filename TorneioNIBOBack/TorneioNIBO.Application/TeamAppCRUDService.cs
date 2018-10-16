using TorneioNIBO.Application.Interface;
using TorneioNIBO.Domain.Entities;
using TorneioNIBO.Domain.Interfaces.Services;

namespace TorneioNIBO.Application
{
    public class TeamAppCRUDService : AppBaseCRUDService<Team>, ITeamAppCRUDService
    {
        public TeamAppCRUDService(ITeamCRUDService serviceBase) : base(serviceBase)
        {
        }
    }
}
