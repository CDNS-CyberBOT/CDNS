namespace CDNS.DAL.Models.Models
{
    public class User
    {
        public User()
        {
            DiscordId = 0;
            Name = string.Empty;
            Email = string.Empty;
            Discriminator = string.Empty;
            AvatarHash = string.Empty;
            AvatarUrl = string.Empty;
        }

        public ulong DiscordId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Discriminator { get; set; }
        public string AvatarHash { get; set; }
        public string AvatarUrl { get; set; }
    }
}