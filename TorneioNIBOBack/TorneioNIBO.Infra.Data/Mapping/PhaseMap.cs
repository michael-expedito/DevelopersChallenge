using FluentNHibernate.Mapping;
using TorneioNIBO.Domain.Entities;

namespace TorneioNIBO.Infra.Data.Mapping
{
    public class PhaseMap : ClassMap<Phase>
    {
        public PhaseMap()
        {
            Id(x => x.Id).Column("id").GeneratedBy.Sequence("phase_id_seq");
            Map(x => x.NumberPhase).Column("number_phase");
            Map(x => x.Closed).Column("closed");
            References(x => x.Tournament).Column("id_tournament");
            HasMany(x => x.Matches).Inverse().Cascade.AllDeleteOrphan();
            Table("phase");
        }
    }
}
