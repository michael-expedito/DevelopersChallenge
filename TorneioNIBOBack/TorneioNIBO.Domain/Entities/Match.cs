namespace TorneioNIBO.Domain.Entities
{
    public class Match
    {
        public virtual int? Id { get; set; }
        public virtual int NumberMatch { get; set; }
        public virtual Team FirstTeam { get; set; }
        public virtual Team SecondTeam { get; set; }
        public virtual Team WinnerTeam { get; set; }
        public virtual Phase Phase { get; set; }
    }
}
