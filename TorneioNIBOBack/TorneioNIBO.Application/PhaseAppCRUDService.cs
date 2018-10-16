using TorneioNIBO.Application.Interface;
using TorneioNIBO.Domain.Entities;
using TorneioNIBO.Domain.Interfaces.Services;

namespace TorneioNIBO.Application
{
    public class PhaseAppCRUDService : AppBaseCRUDService<Phase>, IPhaseAppCRUDService
    {
        public PhaseAppCRUDService(IPhaseCRUDService serviceBase) : base(serviceBase)
        {
        }
    }
}
