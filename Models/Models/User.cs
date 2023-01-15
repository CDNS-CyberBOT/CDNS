namespace CDNS.DAL.Models.Models
{
    public class User
    {
        public User()
        {
            Id = 0;
            Username = string.Empty;
            Email = string.Empty;
            Discriminator = string.Empty;
            Avatar = string.Empty;
            AvatarUrl = string.Empty;
            GuildsString = string.Empty;
        }

        public ulong Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Discriminator { get; set; }
        public string Avatar { get; set; }
        public string AvatarUrl { get; set; }
        public string GuildsString { get; set; }
    }
}