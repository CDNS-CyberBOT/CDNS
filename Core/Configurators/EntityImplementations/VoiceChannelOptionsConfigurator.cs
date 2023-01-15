using DAL.Core.Configurators.Implementations;
using DAL.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Core.Configurators.EntityImplementations
{
    public class VoiceChannelOptionsConfigurator : GenericConfigurator<VoiceChannelOptions>
    {
        public override Type[] DependsOn => new[] { typeof(Guild) };

        public override void Configure(ModelBuilder modelBuilder)
        {
            base.Configure(modelBuilder);

            modelBuilder.Entity<VoiceChannelOptions>().HasIndex(vco => vco.Id).IsUnique();
            modelBuilder.Entity<VoiceChannelOptions>().Property(vco => vco.Id).IsRequired().ValueGeneratedOnAdd();

            modelBuilder.Entity<VoiceChannelOptions>()
                .HasOne(vco => vco.Guild)
                .WithOne(g => g.VoiceChannelOptions)
                .HasPrincipalKey<Guild>(g => g.DiscordId)
                .HasForeignKey<VoiceChannelOptions>(vco => vco.GuildId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VoiceChannelOptions>().Property(vco => vco.ChannelId).IsRequired().HasDefaultValue(0);

            modelBuilder.Entity<VoiceChannelOptions>().Property(vco => vco.IsEnabled).IsRequired();
        }
    }
}
