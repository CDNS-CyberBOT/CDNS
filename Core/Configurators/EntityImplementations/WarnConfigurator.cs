using DAL.Core.Configurators.Implementations;
using DAL.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Core.Configurators.EntityImplementations
{
    public class WarnConfigurator : GenericConfigurator<Warn>
    {
        public override Type[] DependsOn => Type.EmptyTypes;

        public override void Configure(ModelBuilder modelBuilder)
        {
            base.Configure(modelBuilder);

            modelBuilder.Entity<Warn>().HasIndex(w => w.Id).IsUnique();
            modelBuilder.Entity<Warn>().Property(w => w.Id).IsRequired().ValueGeneratedOnAdd();

            modelBuilder.Entity<Warn>().Property(w => w.AuthorId).IsRequired();
            modelBuilder.Entity<Warn>()
                .HasOne(w => w.Author)
                .WithMany(u => u.WarnsWhereAuthor)
                .HasForeignKey(w => w.AuthorId)
                .HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Warn>().Property(w => w.GuildId).IsRequired();
            modelBuilder.Entity<Warn>()
                .HasOne(w => w.Guild)
                .WithMany(g => g.WarnsOfServer)
                .HasPrincipalKey(g => g.Id)
                .HasForeignKey(w => w.GuildId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Warn>().Property(w => w.UserId).IsRequired();
            modelBuilder.Entity<Warn>()
                .HasOne(w => w.User)
                .WithMany(u => u.Warns)
                .HasPrincipalKey(u => u.Id)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Warn>().Property(w => w.Reason).IsRequired().HasMaxLength(1000);
            modelBuilder.Entity<Warn>().Property(w => w.Created).IsRequired();
        }
    }
}
