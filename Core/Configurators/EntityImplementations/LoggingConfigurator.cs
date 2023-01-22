using DAL.Core.Configurators.Implementations;
using DAL.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Core.Configurators.EntityImplementations
{
    public class LoggingConfigurator : GenericConfigurator<LoggingOptions>
    {
        public override Type[] DependsOn => new[] { typeof(Guild) };

        public override void Configure(ModelBuilder modelBuilder)
        {
            base.Configure(modelBuilder);

            modelBuilder.Entity<LoggingOptions>().HasIndex(l => l.Id).IsUnique();
            modelBuilder.Entity<LoggingOptions>().Property(l => l.Id).IsRequired().ValueGeneratedOnAdd();

            modelBuilder.Entity<LoggingOptions>()
                .HasOne(l => l.Guild)
                .WithOne(l => l.LoggingOptions)
                .HasPrincipalKey<LoggingOptions>(l => l.GuildId)
                .HasForeignKey<Guild>(g => g.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LoggingOptions>().Property(l => l.ChannelId).IsRequired();
        }
    }
}
