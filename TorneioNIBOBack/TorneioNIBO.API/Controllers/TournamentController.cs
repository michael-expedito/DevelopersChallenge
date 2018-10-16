using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TorneioNIBO.API.Models;
using TorneioNIBO.Application.Interface;
using TorneioNIBO.Domain.DTO;
using TorneioNIBO.Domain.Entities;

namespace TorneioNIBO.API.Controllers
{
    public class TournamentController : ApiController
    {
        private readonly ITournamentAppCRUDService _tournamentAppCRDService;
        private readonly ITournamentAppBusinessService _tournamentAppBusinessService;

        public TournamentController(ITournamentAppCRUDService tournamentAppService, 
            ITournamentAppBusinessService tournamentAppBusinessService)
        {
            this._tournamentAppCRDService = tournamentAppService;
            this._tournamentAppBusinessService = tournamentAppBusinessService;
        }

        public Response<List<TournamentDTO>> Get()
        {
            Response<List<TournamentDTO>> response = new Response<List<TournamentDTO>>();
            List<TournamentDTO> result = new List<TournamentDTO>();
            var list = _tournamentAppCRDService.GetAll().ToList();
            list.ForEach(x => result.Add(new TournamentDTO().ConvertTournamentToDTO(x)));
            response.data = result;
            return response;
        }

        public Response<TournamentDTO> Get([FromUri]int Id)
        {
            Response<TournamentDTO> response = new Response<TournamentDTO>();
            response.data = new TournamentDTO().ConvertTournamentToDTO(_tournamentAppCRDService.GetById(Id));
            response.messages = _tournamentAppCRDService.GetMessages();
            return response;
        }

        public Response<TournamentDTO> Post([FromBody]TournamentDTO tournamentDto)
        {
            Response<TournamentDTO> response = new Response<TournamentDTO>();
            Tournament t = tournamentDto.ConvertToTournament(null);
            _tournamentAppCRDService.Save(t);
            response.data = tournamentDto.ConvertTournamentToDTO(t);
            response.messages = _tournamentAppCRDService.GetMessages();
            return response;
        }

        public Response<TournamentDTO> Put([FromBody]TournamentDTO team)
        {
            Response<TournamentDTO> response = new Response<TournamentDTO>();
            Tournament newtournament = team.ConvertToTournament(null);
            _tournamentAppCRDService.Update(newtournament);
            response.data = team.ConvertTournamentToDTO(newtournament);
            response.messages = _tournamentAppCRDService.GetMessages();
            return response;
        }

        public Response<TournamentDTO> Delete([FromUri]int id)
        {
            Response<TournamentDTO> response = new Response<TournamentDTO>();
            _tournamentAppCRDService.Delete(_tournamentAppCRDService.GetById(id));
            response.messages = _tournamentAppCRDService.GetMessages();
            return response;
        }

        [Route("api/tournament/generate-teams/{numberTeams}")]
        [HttpGet]
        public Response<List<PhaseDTO>> GenerateTeams([FromUri]int numberTeams)
        {
            List<PhaseDTO> phases = _tournamentAppBusinessService.GenerateTeams(numberTeams);
            Response<List<PhaseDTO>> response = new Response<List<PhaseDTO>>();
            response.data = phases;
            response.messages = _tournamentAppBusinessService.GetMessages();
            return response;
        }

        [Route("api/tournament/generate-phases/{numberTeams}")]
        [HttpGet]
        public Response<List<PhaseDTO>> GeneratePhases([FromUri]int numberTeams)
        {
            List<PhaseDTO> phases = _tournamentAppBusinessService.GeneratePhases(numberTeams);
            Response<List<PhaseDTO>> response = new Response<List<PhaseDTO>>();
            response.data = phases;
            return response;
        }

        [Route("api/tournament/close-phase/")]
        [HttpPut]
        public Response<PhaseDTO> GenerateTeams([FromBody]PhaseDTO phase)
        {
            Response<PhaseDTO> response = new Response<PhaseDTO>();
            _tournamentAppBusinessService.ClosePhase(phase);
            response.messages = _tournamentAppBusinessService.GetMessages();
            return response;
        }

        [Route("api/tournament/generate-tree-node-tournament/{idtournament}")]
        [HttpGet]
        public Response<List<TreeNodeDTO>> GenerateTreeNodeTournament([FromUri]int idTournament)
        {
            Response<List<TreeNodeDTO>> response = new Response<List<TreeNodeDTO>>();
            response.data = new List<TreeNodeDTO>();
            response.data.Add(_tournamentAppBusinessService.GenerateTreeNodeTournament(idTournament));
            return response;
        }
    }
}
