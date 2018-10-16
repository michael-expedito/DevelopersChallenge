using FluentNHibernate.Mapping;
using TorneioNIBO.Domain.Entities;

namespace TorneioNIBO.Infra.Data.Mapping
{
    public class MatchMap : ClassMap<Match>
    {
        public MatchMap()
        {
            Id(x => x.Id).Column("id").GeneratedBy.Sequence("match_id_seq");

            Map(x => x.NumberMatch).Column("number_match");
            References(x => x.FirstTeam).Column("id_first_team");
            References(x => x.SecondTeam).Column("id_second_team");
            References(x => x.WinnerTeam).Column("id_winner_team");
            References(x => x.Phase).Column("id_phase").Cascade.All();
            Table("match");
        }
    }
}
