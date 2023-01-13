using CDNS.DAL.Core.Configurators.Implementations;
using CDNS.DAL.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CDNS.DAL.Core.Configurators.EntityImplementations
{
    public class UserConfigurator : GenericConfigurator<User>
    {
        public override Type[] DependsOn => Type.EmptyTypes;

        public override void Configure(ModelBuilder modelBuilder)
        {
            base.Configure(modelBuilder);

            modelBuilder.Entity<User>().HasKey(g => g.DiscordId);
            modelBuilder.Entity<User>().HasIndex(u => u.DiscordId).IsUnique();
            modelBuilder.Entity<User>().Property(u => u.DiscordId).IsRequired();

            modelBuilder.Entity<User>().Property(u => u.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Discriminator).IsRequired().HasMaxLength(5);

            modelBuilder.Entity<User>().Property(u => u.AvatarHash).IsRequired().HasMaxLength(1000);
            modelBuilder.Entity<User>().Property(u => u.AvatarUrl).IsRequired().HasMaxLength(1000);
        }
    }
}