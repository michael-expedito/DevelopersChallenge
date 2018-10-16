using TorneioNIBO.Domain.Entities;
using TorneioNIBO.Domain.Interfaces.Repositories;
using TorneioNIBO.Domain.Interfaces.Services;

namespace TorneioNIBO.Domain.Services
{
    public class PhaseCRUDService : BaseCRUDService<Phase>, IPhaseCRUDService
    {
        public PhaseCRUDService(IPhaseRepository repository) : base(repository)
        {
        }
    }
}
