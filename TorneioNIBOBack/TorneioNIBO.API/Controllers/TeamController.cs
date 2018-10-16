using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TorneioNIBO.API.Models;
using TorneioNIBO.Application.Interface;
using TorneioNIBO.Domain.DTO;
using TorneioNIBO.Domain.Entities;

namespace TorneioNIBO.API.Controllers
{
    public class TeamController : ApiController
    {
        private readonly ITeamAppCRUDService _teamAppService;

        public TeamController(ITeamAppCRUDService teamAppService)
        {
            this._teamAppService = teamAppService;
        }

        public Response<List<TeamDTO>> Get()
        {
            Response<List<TeamDTO>> response = new Response<List<TeamDTO>>();
            List<TeamDTO> result = new List<TeamDTO>();
            var list = _teamAppService.GetAll().ToList();
            list.ForEach(x => result.Add(new TeamDTO().ConvertTeamToDto(x)));
            response.data = result;
            return response;
        }

        public Response<TeamDTO> Post([FromBody]TeamDTO team)
        {
            Response<TeamDTO> response = new Response<TeamDTO>();
            Team t = team.ConvertToTeam();
            _teamAppService.Save(t);
            response.data = team.ConvertTeamToDto(t);
            response.messages = _teamAppService.GetMessages();
            return response;
        }

        public Response<TeamDTO> Put([FromBody]TeamDTO team)
        {
            Response<TeamDTO> response = new Response<TeamDTO>();
            Team t = team.ConvertToTeam();
            _teamAppService.Update(t);
            response.data = team.ConvertTeamToDto(t);
            response.messages = _teamAppService.GetMessages();
            return response;
        }

        public Response<TeamDTO> Get([FromUri]int Id)
        {
            Response<TeamDTO> response = new Response<TeamDTO>();
            response.data = new TeamDTO().ConvertTeamToDto(_teamAppService.GetById(Id));
            response.messages = _teamAppService.GetMessages();
            return response;
        }

        public Response<TeamDTO> Delete([FromUri]int Id)
        {
            Response<TeamDTO> response = new Response<TeamDTO>();
            _teamAppService.Delete(new Team() { Id = Id });
            response.messages = _teamAppService.GetMessages();
            return response;
        }
    }
}
