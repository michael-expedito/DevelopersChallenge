using TorneioNIBO.Domain.Entities;

namespace TorneioNIBO.Domain.DTO
{
    public class MatchDTO
    {
        public int? Id { get; set; }
        public int NumberMatch { get; set; }
        public PhaseDTO Phase { get; set; }
        public TeamDTO FirstTeam { get; set; }
        public TeamDTO SecondTeam { get; set; }
        public TeamDTO WinnerTeam { get; set; }

        public Match ConvertToMatch(Match match)
        {
            if (match == null)
            {
                match = new Match();
            }
            match.Id = this.Id;
            match.NumberMatch = this.NumberMatch;
            match.Phase = this.Phase.ConvertToPhase(match.Phase);
            match.FirstTeam = this.FirstTeam.ConvertToTeam();
            match.SecondTeam = this.SecondTeam.ConvertToTeam();
            match.WinnerTeam = this.WinnerTeam.ConvertToTeam();

            return match;
        }

        public MatchDTO ConvertToDTO(Match match)
        {
            Id = match.Id;
            NumberMatch = match.NumberMatch;
            Phase = Phase.ConvertToDTO(match.Phase);
            SecondTeam = SecondTeam.ConvertTeamToDto(match.SecondTeam);
            FirstTeam = FirstTeam.ConvertTeamToDto(match.FirstTeam);
            WinnerTeam = WinnerTeam.ConvertTeamToDto(match.WinnerTeam);
            return this;
        }
    }
}
