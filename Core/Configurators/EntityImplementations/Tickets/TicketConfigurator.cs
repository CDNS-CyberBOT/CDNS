using DAL.Core.Configurators.Implementations;
using DAL.Models.Models;
using DAL.Models.Models.Tickets;
using Microsoft.EntityFrameworkCore;

namespace DAL.Core.Configurators.EntityImplementations.Tickets
{
    public class TicketConfigurator : GenericConfigurator<Ticket>
    {
        public override Type[] DependsOn => new[] { typeof(Guild), typeof(TicketOptions) };

        public override void Configure(ModelBuilder modelBuilder)
        {
            base.Configure(modelBuilder);

            modelBuilder.Entity<Ticket>().HasIndex(t => t.Id).IsUnique();
            modelBuilder.Entity<Ticket>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();

            modelBuilder.Entity<Ticket>().Property(t => t.IsOpened).IsRequired();

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Options)
                .WithMany(to => to.Tickets)
                .HasPrincipalKey(to => to.Id)
                .HasForeignKey(t => t.OptionsId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Guild)
                .WithMany(g => g.Tickets)
                .HasPrincipalKey(g => g.Id)
                .HasForeignKey(t => t.GuildId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Ticket>().Property(t => t.IdInGuild).IsRequired();

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.TicketsWhereOwner)
                .HasPrincipalKey(u => u.Id)
                .HasForeignKey(t => t.CreatorDiscordId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Ticket>().Property(t => t.CreatedTime).IsRequired().HasDefaultValue(DateTime.Now);
        }
    }
}
