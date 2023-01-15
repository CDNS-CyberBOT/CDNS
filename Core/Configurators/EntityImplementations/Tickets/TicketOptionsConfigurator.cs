using DAL.Core.Configurators.Implementations;
using DAL.Models.Models;
using DAL.Models.Models.Tickets;
using Microsoft.EntityFrameworkCore;

namespace DAL.Core.Configurators.EntityImplementations.Tickets
{
    public class TicketOptionsConfigurator : GenericConfigurator<TicketOptions>
    {
        public override Type[] DependsOn => new[] { typeof(Guild) };

        public override void Configure(ModelBuilder modelBuilder)
        {
            base.Configure(modelBuilder);

            modelBuilder.Entity<TicketOptions>().HasIndex(to => to.Id).IsUnique();
            modelBuilder.Entity<TicketOptions>().Property(to => to.Id).IsRequired().ValueGeneratedOnAdd();

            modelBuilder.Entity<TicketOptions>().Property(to => to.SupportTeamRoles).IsRequired().HasDefaultValue(string.Empty);

            modelBuilder.Entity<TicketOptions>().Property(to => to.AdditionalRoles).IsRequired().HasDefaultValue(string.Empty);

            modelBuilder.Entity<TicketOptions>().Property(to => to.IsTwoStepClose).IsRequired();
            modelBuilder.Entity<TicketOptions>().Property(to => to.IsTwoStepTicket).IsRequired();
            modelBuilder.Entity<TicketOptions>().Property(to => to.IsAutoPinTicket).IsRequired();

            modelBuilder.Entity<TicketOptions>().Property(to => to.CategoryForCreatedOpenedTickets).IsRequired().HasDefaultValue(0);
            modelBuilder.Entity<TicketOptions>().Property(to => to.CategoryForClosedTickets).IsRequired().HasDefaultValue(0);

            modelBuilder.Entity<TicketOptions>().Property(to => to.OpenedTicketName).IsRequired().HasDefaultValue("ticket-{count}");
            modelBuilder.Entity<TicketOptions>().Property(to => to.ClosedTicketName).IsRequired().HasDefaultValue("closed-{count}");

            modelBuilder.Entity<TicketOptions>().Property(to => to.AddRoleForTicketOwnerOnOpened).IsRequired().HasDefaultValue(string.Empty);
            modelBuilder.Entity<TicketOptions>().Property(to => to.RemoveRoleForTicketOwnerOnOpened).IsRequired().HasDefaultValue(string.Empty);

            modelBuilder.Entity<TicketOptions>().Property(to => to.AddRoleForTicketOwnerOnClosed).IsRequired().HasDefaultValue(string.Empty);
            modelBuilder.Entity<TicketOptions>().Property(to => to.RemoveRoleForTicketOwnerOnClosed).IsRequired().HasDefaultValue(string.Empty);

            modelBuilder.Entity<TicketOptions>().Property(to => to.TicketCount).IsRequired().HasMaxLength(4).HasDefaultValue(0000);

            modelBuilder.Entity<TicketOptions>()
                .HasOne(to => to.Guild)
                .WithOne(g => g.TicketOptions)
                .HasPrincipalKey<Guild>(g => g.DiscordId)
                .HasForeignKey<TicketOptions>(to => to.GuildId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
