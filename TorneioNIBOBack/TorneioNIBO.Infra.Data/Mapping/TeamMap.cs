using FluentNHibernate.Mapping;
using TorneioNIBO.Domain.Entities;

namespace TorneioNIBO.Infra.Data.Mapping
{
    public class TeamMap : ClassMap<Team>
    {
        public TeamMap()
        {
            Id(x => x.Id).Column("id").GeneratedBy.Sequence("team_id_seq");
            Map(x => x.Name);
            Map(x => x.Description);
            Table("team");
        }
    }
}
