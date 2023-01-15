namespace DAL.Models.Models
{
    public class Warn
    {

        public Warn()
        {
            Id = 0;
            AuthorId = 0;
            GuildId = 0;
            UserId = 0;
            Reason = "";
            Created = DateTime.Now;
        }

        public int Id { get; set; }
        public ulong AuthorId { get; set; }
        public virtual User? Author { get; set; }
        public ulong GuildId { get; set; }
        public virtual Guild? Guild { get; set; }
        public ulong UserId { get; set; }
        public virtual User? User { get; set; }
        public string Reason { get; set; }
        public DateTime Created { get; set; }
    }
}
