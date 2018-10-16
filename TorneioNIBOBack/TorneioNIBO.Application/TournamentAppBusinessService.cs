using System;
using System.Collections.Generic;
using TorneioNIBO.Application;
using TorneioNIBO.Application.Interface;
using TorneioNIBO.Domain;
using TorneioNIBO.Domain.DTO;
using TorneioNIBO.Domain.Entities;
using TorneioNIBO.Domain.Interfaces.Services;
using TorneioNIBO.Domain.Services;

namespace TorneioNIBO.Application
{
    public class TournamentAppBusinessService : AppBaseBusinessService<ITournamentBusinessService>, ITournamentAppBusinessService
    {
        public TournamentAppBusinessService(ITournamentBusinessService serviceBase) : base(serviceBase)
        {
        }

        public void ClosePhase(PhaseDTO phaseDto)
        {
            _serviceBusinessBase.ClosePhase(phaseDto);
        }

        public List<PhaseDTO> GeneratePhases(int numberTeams)
        {
            return _serviceBusinessBase.GeneratePhases(numberTeams);
        }

        public List<PhaseDTO> GenerateTeams(int numberTeams)
        {
            return _serviceBusinessBase.GenerateTeams(numberTeams);
        }

        public TreeNodeDTO GenerateTreeNodeTournament(int idTournament)
        {
            return _serviceBusinessBase.GenerateTreeNodeTournament(idTournament);
        }
    }
}
