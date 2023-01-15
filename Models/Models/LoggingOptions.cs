namespace DAL.Models.Models
{
    public class LoggingOptions
    {
        public int Id { get; set; }
        public ulong GuildId { get; set; }
        public virtual Guild? Guild { get; set; }
        public ulong ChannelId { get; set; }
        public bool IsEnabled { get; set; }
    }
}
