using System.Collections.Generic;
using TorneioNIBO.Domain.Entities;

namespace TorneioNIBO.Domain.DTO
{
    public class TournamentDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int NumberTeams { get; set; }
        public int NumberPhases { get; set; }
        public List<PhaseDTO> Phases { get; set; }

        public TournamentDTO ConvertTournamentToDTO(Tournament tournament)
        {
            Id = tournament.Id;
            Name = tournament.Name;
            NumberPhases = tournament.NumberPhases;
            NumberTeams = tournament.NumberTeams;

            Phases = new List<PhaseDTO>();
            foreach (var p in tournament.Phases)
            {
                PhaseDTO pDto = new PhaseDTO();
                pDto.Id = p.Id;
                pDto.NumberPhase = p.NumberPhase;
                pDto.Closed = p.Closed;

                pDto.Matches = new List<MatchDTO>();
                foreach (var m in p.Matches)
                {
                    MatchDTO mDto = new MatchDTO();
                    mDto.Id = m.Id;
                    mDto.NumberMatch = m.NumberMatch;
                    mDto.FirstTeam = m.FirstTeam != null ? new TeamDTO() { Id = m.FirstTeam.Id, Name = m.FirstTeam.Name, Description = m.FirstTeam.Description } : null;
                    mDto.SecondTeam = m.SecondTeam != null ? new TeamDTO() { Id = m.SecondTeam.Id, Name = m.SecondTeam.Name, Description = m.SecondTeam.Description } : null;
                    mDto.WinnerTeam = m.WinnerTeam != null ? new TeamDTO() { Id = m.WinnerTeam.Id, Name = m.WinnerTeam.Name, Description = m.WinnerTeam.Description } : null;
                    pDto.Matches.Add(mDto);
                }
                pDto.Matches.Sort((x, y) => x.NumberMatch.CompareTo(y.NumberMatch));
                
                Phases.Add(pDto);
            }
            Phases.Sort((x, y) => x.NumberPhase.CompareTo(y.NumberPhase));
            return this;
        }

        public Tournament ConvertToTournament(Tournament tournament)
        {
            if (tournament == null)
            {
                tournament = new Tournament();
            }
            tournament.Id = this.Id;
            tournament.Name = this.Name;
            tournament.NumberPhases = this.NumberPhases;
            tournament.NumberTeams = this.NumberTeams;

            if (tournament.Phases == null)
            {
                tournament.Phases = new List<Phase>();
            }
            tournament.Phases.Clear();

            foreach (var p in Phases)
            {
                Phase phase = new Phase();
                phase.Id = p.Id;
                phase.NumberPhase = p.NumberPhase;
                phase.Tournament = tournament;
                phase.Matches = new List<Match>();
                phase.Closed = p.Closed;
                foreach (var m in p.Matches)
                {
                    Match match = new Match();
                    match.Id = m.Id;
                    match.Phase = phase;
                    match.NumberMatch = m.NumberMatch;
                    match.FirstTeam = m.FirstTeam != null ? new Team() { Id = m.FirstTeam.Id, Name = m.FirstTeam.Name, Description = m.FirstTeam.Description } : null;
                    match.SecondTeam = m.SecondTeam != null ? new Team() { Id = m.SecondTeam.Id, Name = m.SecondTeam.Name, Description = m.SecondTeam.Description } : null;
                    match.WinnerTeam = m.WinnerTeam != null ? new Team() { Id = m.WinnerTeam.Id, Name = m.WinnerTeam.Name, Description = m.WinnerTeam.Description } : null;
                    phase.Matches.Add(match);
                }
                tournament.Phases.Add(phase);
            }
            return tournament;
        }
    }
}
