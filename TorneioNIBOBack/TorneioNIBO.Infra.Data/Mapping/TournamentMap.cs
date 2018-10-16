using FluentNHibernate.Mapping;
using TorneioNIBO.Domain.Entities;

namespace TorneioNIBO.Infra.Data.Mapping
{
    public class TournamentMap : ClassMap<Tournament>
    {
        public TournamentMap()
        {
            Id(x => x.Id).Column("id").GeneratedBy.Sequence("tournament_id_seq");
            Map(x => x.Name);
            Map(x => x.NumberTeams).Column("number_teams");
            Map(x => x.NumberPhases).Column("number_phases");
            HasMany(x => x.Phases).Cascade.AllDeleteOrphan().Inverse().LazyLoad();
            Table("tournament");
        }
    }
}
