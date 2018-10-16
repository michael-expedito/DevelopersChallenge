using TorneioNIBO.Domain.Entities;

namespace TorneioNIBO.Domain.DTO
{
    public class TeamDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public TeamDTO ConvertTeamToDto(Team team)
        {
            Id = team.Id;
            Name = team.Name;
            Description = team.Description;

            return this;
        }

        public Team ConvertToTeam()
        {
            return new Team() { Id = this.Id, Name = this.Name, Description = this.Description };
        }
    }
}
