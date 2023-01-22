using DAL.Core.Configurators.Implementations;
using DAL.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Core.Configurators.EntityImplementations
{
    public class GuildConfigurator : GenericConfigurator<Guild>
    {
        public override Type[] DependsOn => new[] { typeof(User) };

        public override void Configure(ModelBuilder modelBuilder)
        {
            base.Configure(modelBuilder);

            modelBuilder.Entity<Guild>().HasKey(g => g.Id);
            modelBuilder.Entity<Guild>().HasIndex(g => g.Id).IsUnique();
            modelBuilder.Entity<Guild>().Property(g => g.Id).IsRequired();

            modelBuilder.Entity<Guild>().Property(g => g.Name).IsRequired();

            modelBuilder.Entity<Guild>()
                .HasOne(g => g.Owner)
                .WithMany(u => u.GuildsWhereOwner)
                .HasForeignKey(g => g.OwnerId)
                .HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.NoAction) 
                .IsRequired();

            modelBuilder.Entity<Guild>().Property(g => g.IsGuildAvailable).IsRequired();

            modelBuilder.Entity<Guild>().Property(g => g.IsGuildPremium).IsRequired();

            modelBuilder.Entity<Guild>().Property(g => g.IconHash);
            modelBuilder.Entity<Guild>().Property(g => g.IconUrl);

            modelBuilder.Entity<Guild>().Property(g => g.WarnDuration).IsRequired();
        }
    }
}
