namespace DAL.Models.Models.Tickets
{
    public class Ticket
    {
        public int Id { get; set; }
        public ulong ChannelId { get; set; }
        public bool IsOpened { get; set; }

        public int OptionsId { get; set; }
        public virtual TicketOptions? Options { get; set; }

        public ulong GuildId { get; set; }
        public virtual Guild? Guild { get; set; }

        public int IdInGuild { get; set; }
        
        public ulong CreatorDiscordId { get; set; }
        public virtual User? User { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
