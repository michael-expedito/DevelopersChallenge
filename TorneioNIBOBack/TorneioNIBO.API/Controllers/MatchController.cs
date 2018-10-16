using System.Web.Http;
using TorneioNIBO.API.Models;
using TorneioNIBO.Application.Interface;
using TorneioNIBO.Domain.DTO;
using TorneioNIBO.Domain.Entities;

namespace TorneioNIBO.API.Controllers
{
    public class MatchController : ApiController
    {
        private readonly IPhaseAppCRUDService _phaseAppCRUDService;

        public MatchController(IPhaseAppCRUDService phaseAppCRUDService)
        {
            _phaseAppCRUDService = phaseAppCRUDService;
        }

    }
}
