using System.Collections.Generic;
using TorneioNIBO.Domain.DTO;

namespace TorneioNIBO.Domain.Interfaces.Services
{
    public interface ITournamentBusinessService : IBaseBusinessService
    {
        List<PhaseDTO> GeneratePhases(int numberTeams);
        List<PhaseDTO> GenerateTeams(int numberTeams);
        void ClosePhase(PhaseDTO phaseDto);
        TreeNodeDTO GenerateTreeNodeTournament(int idTournament);
    }
}
