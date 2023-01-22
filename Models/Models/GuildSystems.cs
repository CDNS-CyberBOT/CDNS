namespace DAL.Models.Models
{
    public class GuildSystems
    {
        public ulong Id { get; set; }
        public ulong GuildId { get; set; }
        public virtual Guild? Guild { get; set; }

        public bool IsTicketSystemEnabled { get; set; }
        public bool IsLoggingEnabled { get; set; }
        public bool IsStatisticEnabled { get; set; }
        public bool IsDynamicVoiceChannelsEnabled { get; set; }
    }
}
