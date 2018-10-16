using System.Collections.Generic;

namespace TorneioNIBO.Domain.Entities
{
    public class Tournament
    {
        public virtual int? Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int NumberTeams { get; set; }
        public virtual int NumberPhases { get; set; }
        public virtual IList<Phase> Phases { get; set; }
    }
}
