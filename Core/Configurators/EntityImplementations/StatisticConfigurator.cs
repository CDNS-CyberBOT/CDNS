using DAL.Core.Configurators.Implementations;
using DAL.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Core.Configurators.EntityImplementations
{
    public class StatisticConfigurator : GenericConfigurator<Statistic>
    {
        public override Type[] DependsOn => new[] { typeof(Guild) };

        public override void Configure(ModelBuilder modelBuilder)
        {
            base.Configure(modelBuilder);

            modelBuilder.Entity<Statistic>().HasIndex(s => s.Id).IsUnique();
            modelBuilder.Entity<Statistic>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();

            modelBuilder.Entity<Statistic>()
                .HasOne(s => s.Guild)
                .WithOne(g => g.Statistic)
                .HasPrincipalKey<Statistic>(s => s.GuildId)
                .HasForeignKey<Guild>(g => g.DiscordId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Statistic>().Property(s => s.CategoryId).IsRequired().HasDefaultValue(0);

            modelBuilder.Entity<Statistic>().Property(s => s.IsEnabled).IsRequired();

            modelBuilder.Entity<Statistic>().Property(s => s.Users).IsRequired().HasDefaultValue(0);
            modelBuilder.Entity<Statistic>().Property(s => s.UsersCountChannelId).IsRequired().HasDefaultValue(0);

            modelBuilder.Entity<Statistic>().Property(s => s.Boosts).IsRequired().HasDefaultValue(0);
            modelBuilder.Entity<Statistic>().Property(s => s.BoostsCountChannelId).IsRequired().HasDefaultValue(0);

            modelBuilder.Entity<Statistic>().Property(s => s.Bots).IsRequired().HasDefaultValue(0);
            modelBuilder.Entity<Statistic>().Property(s => s.BotsCountChannelId).IsRequired().HasDefaultValue(0);

            modelBuilder.Entity<Statistic>().Property(s => s.Roles).IsRequired().HasDefaultValue(0);
            modelBuilder.Entity<Statistic>().Property(s => s.RolesCountChannelId).IsRequired().HasDefaultValue(0);
        }
    }
}
