namespace CDNS.DAL.Models.Models
{
    public class DiscordGuild
    {
        public DiscordGuild()
        {
            Id = 0;
            Name = string.Empty;
            IconHash = string.Empty;
            IsOwner = false;
            Permissions = 0;
            Features = new string[] {};
            PermissionsNew = string.Empty;
        }

        public ulong Id { get; set; }
        public string Name { get; set; }
        public string IconHash { get; set; }
        public bool IsOwner { get; set; }
        public int Permissions { get; set; }
        public string[] Features { get; set; }
        public string PermissionsNew { get; set; }
    }
}
