using DAL.Core.Configurators.Implementations;
using DAL.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Core.Configurators.EntityImplementations
{
    public class UserConfigurator : GenericConfigurator<User>
    {
        public override Type[] DependsOn => Type.EmptyTypes;

        public override void Configure(ModelBuilder modelBuilder)
        {
            base.Configure(modelBuilder);

            modelBuilder.Entity<User>().HasKey(g => g.Id);
            modelBuilder.Entity<User>().HasIndex(u => u.Id).IsUnique();
            modelBuilder.Entity<User>().Property(u => u.Id).IsRequired();

            modelBuilder.Entity<User>().Property(u => u.Username).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Discriminator).IsRequired().HasMaxLength(5);

            modelBuilder.Entity<User>().Property(u => u.Avatar).IsRequired().HasMaxLength(1000);
            modelBuilder.Entity<User>().Property(u => u.AvatarUrl).IsRequired().HasMaxLength(1000);

            modelBuilder.Entity<User>().Property(u => u.GuildsString).IsRequired().HasMaxLength(65535);
        }
    }
}