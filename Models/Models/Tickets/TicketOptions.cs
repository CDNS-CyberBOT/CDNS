namespace DAL.Models.Models.Tickets
{
    public class TicketOptions
    {
        public TicketOptions()
        {
            IsEnabled = false;

            SupportTeamRoles = string.Empty;
            AdditionalRoles = string.Empty;

            IsTwoStepClose = true;
            IsTwoStepTicket = true;
            IsAutoPinTicket = true;

            CategoryForCreatedOpenedTickets = 0;
            CategoryForCreatedOpenedTickets = 0;

            OpenedTicketName = "ticket-{count}";
            ClosedTicketName = "closed-{count}";

            AddRoleForTicketOwnerOnOpened = string.Empty;
            RemoveRoleForTicketOwnerOnOpened = string.Empty;

            AddRoleForTicketOwnerOnClosed = string.Empty;
            RemoveRoleForTicketOwnerOnClosed = string.Empty;
        }

        public int Id { get; set; }

        public bool IsEnabled { get; set; }

        public string SupportTeamRoles { get; set; }
        public string AdditionalRoles { get; set; }
        
        public bool IsTwoStepClose { get; set; }
        public bool IsTwoStepTicket { get; set; }
        public bool IsAutoPinTicket { get; set; }
        
        public ulong CategoryForCreatedOpenedTickets { get; set; }
        public ulong CategoryForClosedTickets { get; set; }
        
        public string OpenedTicketName { get; set; }
        public string ClosedTicketName { get; set; }

        public string AddRoleForTicketOwnerOnOpened { get; set; }
        public string RemoveRoleForTicketOwnerOnOpened { get; set; }

        public string AddRoleForTicketOwnerOnClosed { get; set; }
        public string RemoveRoleForTicketOwnerOnClosed { get; set; }

        public short TicketCount { get; set; }

        public ulong GuildId { get; set; }
        public virtual Guild? Guild { get; set; }

        public virtual List<Ticket>? Tickets { get; set; }
    }
}
