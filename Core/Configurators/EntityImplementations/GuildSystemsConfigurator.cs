using DAL.Core.Configurators.Implementations;
using DAL.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Core.Configurators.EntityImplementations
{
    public class GuildSystemsConfigurator : GenericConfigurator<GuildSystems>
    {
        public override Type[] DependsOn => new[] { typeof(Guild) };

        public override void Configure(ModelBuilder modelBuilder)
        {
            base.Configure(modelBuilder);

            modelBuilder.Entity<GuildSystems>().HasKey(gs => gs.Id);
            modelBuilder.Entity<GuildSystems>().HasIndex(gs => gs.Id).IsUnique();
            modelBuilder.Entity<GuildSystems>().Property(gs => gs.Id).IsRequired().ValueGeneratedOnAdd();

            modelBuilder.Entity<GuildSystems>()
                .HasOne(gs => gs.Guild)
                .WithOne(g => g.Systems)
                .HasForeignKey<Guild>(g => g.Id)
                .HasPrincipalKey<GuildSystems>(gs => gs.GuildId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<GuildSystems>().Property(g => g.IsTicketSystemEnabled).IsRequired();
            modelBuilder.Entity<GuildSystems>().Property(g => g.IsLoggingEnabled).IsRequired();
            modelBuilder.Entity<GuildSystems>().Property(g => g.IsStatisticEnabled).IsRequired();
            modelBuilder.Entity<GuildSystems>().Property(g => g.IsDynamicVoiceChannelsEnabled).IsRequired();
        }
    }
}
