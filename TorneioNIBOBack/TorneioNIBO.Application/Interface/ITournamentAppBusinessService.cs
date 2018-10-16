using System.Collections.Generic;
using TorneioNIBO.Domain.DTO;
using TorneioNIBO.Domain.Interfaces.Services;

namespace TorneioNIBO.Application.Interface
{
    public interface ITournamentAppBusinessService : IAppBaseBusinessService<ITournamentBusinessService>
    {
        List<PhaseDTO> GeneratePhases(int numberTeams);
        List<PhaseDTO> GenerateTeams(int numberTeams);
        void ClosePhase(PhaseDTO phaseDto);
        TreeNodeDTO GenerateTreeNodeTournament(int idTournament);
    }
}
