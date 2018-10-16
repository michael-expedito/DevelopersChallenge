using System.Web.Http;
using TorneioNIBO.API.Models;
using TorneioNIBO.Application.Interface;
using TorneioNIBO.Domain.DTO;
using TorneioNIBO.Domain.Entities;

namespace TorneioNIBO.API.Controllers
{
    public class PhaseController : ApiController
    {

        private readonly IPhaseAppCRUDService _phaseAppCRUDService;
        private readonly ITournamentAppBusinessService _tournamentAppBusinessService;

        public PhaseController(IPhaseAppCRUDService phaseAppCRUDService,
            ITournamentAppBusinessService tournamentAppBusinessService)
        {
            this._phaseAppCRUDService = phaseAppCRUDService;
            this._tournamentAppBusinessService = tournamentAppBusinessService;
        }

        public Response<PhaseDTO> Put([FromBody]PhaseDTO phase)
        {
            Response<PhaseDTO> response = new Response<PhaseDTO>();
            Phase updatePhase = _phaseAppCRUDService.GetById(phase.Id); 

            for (int i = 0; i < updatePhase.Matches.Count; i++)
            {
                updatePhase.Matches[i].WinnerTeam = phase.Matches.Find(x => x.NumberMatch == updatePhase.Matches[i].NumberMatch).WinnerTeam?.ConvertToTeam();
            }

            _phaseAppCRUDService.Update(updatePhase);
            response.data = phase.ConvertToDTO(updatePhase);
            response.messages = _phaseAppCRUDService.GetMessages();
            return response;
        }
    }
}