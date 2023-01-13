namespace CDNS.DAL.Models.Models
{
    public static class DiscordUser
    {
        static DiscordUser()
        {
            Id = 0;
            Username = string.Empty;
            Email = string.Empty;
            Discriminator = string.Empty;
            Locale = string.Empty;
            GuildsString = string.Empty;
        }

        public static ulong Id { get; set; }
        public static string Username { get; set; }
        public static string Email { get; set; }
        public static string Discriminator { get; set; }
        public static string? AvatarHash { get; set; }
        public static string? BannerHash { get; set; }
        public static string Locale { get; set; }
        public static string GuildsString { get; set; }

    }
}
