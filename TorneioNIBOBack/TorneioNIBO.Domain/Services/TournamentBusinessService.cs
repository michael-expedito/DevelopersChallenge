using System;
using System.Collections.Generic;
using TorneioNIBO.Domain.DTO;
using TorneioNIBO.Domain.Entities;
using TorneioNIBO.Domain.Interfaces.Services;

namespace TorneioNIBO.Domain.Services
{
    public class TournamentBusinessService : BaseBusinessService, ITournamentBusinessService
    {
        private readonly ITeamCRUDService _teamCRUDService;
        private readonly ITournamentCRUDService _tournamentCRUDService;
        private readonly IPhaseCRUDService _phaseCRUDService;


        public TournamentBusinessService(ITeamCRUDService teamCRUDService,
            ITournamentCRUDService tournamentCRUDService,
            IPhaseCRUDService phaseCRUDService)
        {
            _teamCRUDService = teamCRUDService;
            _tournamentCRUDService = tournamentCRUDService;
            _phaseCRUDService = phaseCRUDService;
        }

        public List<PhaseDTO> GeneratePhases(int numberTeams)
        {
            int div = 0;
            int numberPhase = 1;
            List<PhaseDTO> phaseResult = new List<PhaseDTO>();
            while (div != 1)
            {
                div = div == 0 ? numberTeams / 2 : div / 2;
                PhaseDTO phase = new PhaseDTO()
                {
                    Id = null,
                    NumberPhase = numberPhase,
                    Matches = new List<MatchDTO>(),
                    Closed = numberPhase == 1 ? false : true
                };

                for (int index = 1; index <= div; index++)
                {
                    phase.Matches.Add(new MatchDTO()
                    {
                        Id = null,
                        NumberMatch = index,
                        FirstTeam = null,
                        SecondTeam = null,
                        WinnerTeam = null
                    });
                }
                numberPhase++;
                phaseResult.Add(phase);
            }
            return phaseResult;
        }

        public List<PhaseDTO> GenerateTeams(int numberTeams)
        {
            IList<Team> teams = _teamCRUDService.GetAll();
            List<PhaseDTO> phasesDto = GeneratePhases(numberTeams);
            if (teams.Count < numberTeams)
            {
                messages.Add(new Message("", MessageType.error, "Não temos times suficientes cadastrados"));
            }
            else
            {
                List<Team> teamsRandon = new List<Team>();
                Random randNum = new Random();
                while (teams.Count > 0)
                {
                    int val = randNum.Next(0, teams.Count - 1);
                    teamsRandon.Add(teams[val]);
                    teams.RemoveAt(val);
                }
                int teamIndex = 0;
                for (int i = 0; i < phasesDto[0].Matches.Count; i++)
                {
                    TeamDTO firstTeam = new TeamDTO().ConvertTeamToDto(teamsRandon[teamIndex]);
                    teamIndex++;
                    TeamDTO secondTeam = new TeamDTO().ConvertTeamToDto(teamsRandon[teamIndex]);
                    teamIndex++;
                    phasesDto[0].Matches[i].FirstTeam = firstTeam;
                    phasesDto[0].Matches[i].SecondTeam = secondTeam;
                }
            }

            return phasesDto;

        }

        public void ClosePhase(PhaseDTO phaseDto)
        {
            Phase pDto = _phaseCRUDService.GetById(phaseDto.Id);

            Tournament t = _tournamentCRUDService.GetById(pDto.Tournament.Id);

            foreach (var phase in t.Phases)
            {
                if (phase.NumberPhase == pDto.NumberPhase + 1)
                {
                    List<Match> matches = new List<Match>();
                    foreach (var temp in pDto.Matches)
                    {
                        matches.Add(temp);
                    }

                    foreach (var match in phase.Matches)
                    {
                        var firstMatch = matches.Find(x => x.NumberMatch == (match.NumberMatch + match.NumberMatch - 1));
                        var secondMatch = matches.Find(x => x.NumberMatch == (match.NumberMatch + match.NumberMatch));

                        match.FirstTeam = firstMatch?.WinnerTeam;
                        match.SecondTeam = secondMatch?.WinnerTeam;
                    }
                    phase.Closed = false;
                }
                else
                {
                    if (t.Phases.Count == pDto.NumberPhase && pDto.NumberPhase == phase.NumberPhase)
                    {
                        phase.Matches[0].WinnerTeam = phaseDto.Matches[0].WinnerTeam.ConvertToTeam();
                        messages.Add(new Message("TOR02", MessageType.success, String.Concat("Parabens ao time ", phase.Matches[0].WinnerTeam.Name, " que é o campeão do torneio ", t.Name, "!")));
                        phase.Closed = true;
                    }
                    phase.Closed = true;
                }
            }

            _tournamentCRUDService.Update(t);
            messages.Add(new Message("TOR01", MessageType.success, "Fase fechada com sucesso!"));
        }

        public TreeNodeDTO GenerateTreeNodeTournament(int idTournament)
        {
            TreeNodeDTO tree = new TreeNodeDTO();
            Tournament t = _tournamentCRUDService.GetById(idTournament);
            List<Phase> phases = new List<Phase>();
            phases.AddRange(t.Phases);

            phases.Sort((x, y) => y.NumberPhase.CompareTo(x.NumberPhase));

            tree.label = phases[0].Matches[0].WinnerTeam == null ? "Aguardando final" : phases[0].Matches[0].WinnerTeam.Name;
            tree.expanded = true;
            tree.children = generateChildren(phases, phases[0].Matches[0], 1);

            return tree;
        }

        private List<TreeNodeDTO> generateChildren(List<Phase> phases, Match matchFather, int nextPhaseIndex)
        {
            List<TreeNodeDTO> listChildren = new List<TreeNodeDTO>();
            foreach (var m in phases[nextPhaseIndex].Matches)
            {
                if ((m.NumberMatch == (matchFather.NumberMatch + matchFather.NumberMatch - 1))
                    || (m.NumberMatch == (matchFather.NumberMatch + matchFather.NumberMatch)))
                {
                    string label = m.WinnerTeam?.Name;
                    listChildren.Add(new TreeNodeDTO()
                    {
                        label = m.WinnerTeam == null ? "Aguardando partida" : m.WinnerTeam.Name,
                        expanded = true,
                        children = phases[nextPhaseIndex].NumberPhase > 1 
                            ? generateChildren(phases, m, nextPhaseIndex + 1) 
                            : new List<TreeNodeDTO>() {
                                new TreeNodeDTO() { label = m.FirstTeam.Name, expanded = true },
                                new TreeNodeDTO() { label = m.SecondTeam.Name, expanded = true }
                            }
                    });
                }
            }
            return listChildren;
        }

    }
}
