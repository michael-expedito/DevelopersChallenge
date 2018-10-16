using System.Collections.Generic;

namespace TorneioNIBO.Domain.Entities
{
    public class Phase
    {
        public virtual int? Id { get; set; }
        public virtual int NumberPhase { get; set; }
        public virtual Tournament Tournament { get; set; }
        public virtual IList<Match> Matches { get; set; }
        public virtual bool Closed { get; set; }
    }
}
