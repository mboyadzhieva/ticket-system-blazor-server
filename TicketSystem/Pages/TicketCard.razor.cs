namespace TicketSystem.Pages
{
    using Microsoft.AspNetCore.Components;
    using TicketSystem.Models;

    public partial class TicketCard
    {
        [Parameter]
        public TicketModel Ticket { get; set; }

    }
}
