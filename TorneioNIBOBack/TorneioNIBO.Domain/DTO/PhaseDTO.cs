using System.Collections.Generic;
using TorneioNIBO.Domain.Entities;

namespace TorneioNIBO.Domain.DTO
{
    public class PhaseDTO
    {
        public int? Id { get; set; }
        public int NumberPhase { get; set; }
        public List<MatchDTO> Matches { get; set; }
        public bool Closed { get; set; }

        public Phase ConvertToPhase(Phase phase)
        {
            if (phase == null)
            {
                phase = new Phase();
            }
            phase.Id = this.Id;
            phase.NumberPhase = this.NumberPhase;
            phase.Closed = this.Closed;
            return phase;
        }

        public PhaseDTO ConvertToDTO(Phase phase)
        {
            Id = phase.Id;
            NumberPhase = phase.NumberPhase;
            Closed = phase.Closed;
            return this;
        }
    }
}
