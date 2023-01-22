namespace DAL.Models.Models
{
    public class VoiceChannelOptions
    {
        public VoiceChannelOptions()
        {
            GuildId = 0;
            ChannelId = 0;
        }

        public int Id { get; set; }

        public ulong GuildId { get; set; }
        public virtual Guild? Guild { get; set; }

        public ulong ChannelId { get; set; }

        public int DefaultUserLimit { get; set; }
    }
}
