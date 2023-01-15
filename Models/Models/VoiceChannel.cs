namespace DAL.Models.Models
{
    public static class VoiceChannel
    {
        static VoiceChannel()
        {
            Id = 0;
            Name = string.Empty;
            OwnerId = 0;
            UserLimit = 2;
            IsEveryoneCanEntrance = false;
            BitRate = 0;
        }

        public static ulong Id { get; set; }

        public static string Name { get; set; }

        public static ulong OwnerId { get; set; }

        public static bool IsEveryoneCanEntrance { get; set; }
        public static int BitRate { get; set; }

        public static int? UserLimit { get; set; }
    }
}
