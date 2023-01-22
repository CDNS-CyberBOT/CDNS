namespace DAL.Models.Models
{
    public class Statistic
    {
        public int Id { get; set; }
        public ulong GuildId { get; set; }
        public virtual Guild? Guild { get; set; }

        public ulong CategoryId { get; set; }
        
        public int Users { get; set; }
        public ulong UsersCountChannelId { get; set; }

        public int Boosts { get; set; }
        public ulong BoostsCountChannelId { get; set; }

        public int Bots { get; set; }
        public ulong BotsCountChannelId { get; set; }

        public int Roles { get; set; }
        public ulong RolesCountChannelId { get; set; }
    }
}
