using DAL.Models.Models.Tickets;

namespace DAL.Models.Models
{
    public class Guild
    {
        public Guild()
        {
            Id = 0;
            Name = "";
            OwnerId = 0;
            IsGuildPremium = false;
            IconHash = "";
            IconUrl = "";
            WarnDuration = 7;
        }
        public ulong Id { get; set; }
        public string Name { get; set; }
        public ulong OwnerId { get; set; }
        public virtual User? Owner { get; set; }
        
        public bool IsGuildAvailable { get; set; }

        public bool IsGuildPremium { get; set; }

        public string? IconHash { get; set; }
        public string? IconUrl { get; set; }

        public int WarnDuration { get; set; }
        
        public virtual TicketOptions? TicketOptions { get; set; }
        public virtual Statistic? Statistic { get; set; }
        public virtual VoiceChannelOptions? VoiceChannelOptions { get; set; }
        public virtual LoggingOptions? LoggingOptions { get; set; }
        public virtual GuildSystems? Systems { get; set; }


        public virtual List<Warn>? WarnsOfServer { get; set; }
        public virtual List<Ticket>? Tickets { get; set; }

    }
}
