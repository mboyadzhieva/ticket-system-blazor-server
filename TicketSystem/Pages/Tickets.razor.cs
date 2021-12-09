namespace TicketSystem.Pages
{
    using Microsoft.AspNetCore.Components;
    using System.Collections.Generic;
    using TicketSystem.Models;
    using TicketSystem.Services;

    public partial class Tickets
    {
        private List<TicketModel> AllTickets { get; set; }

        public string Username { get; set; }

        [Inject]
        private ITicketService TicketService { get; set; }

        [Inject]
        private ICurrentUserService CurrentUser { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (CurrentUser.IsAssignedToRole("OfficeSupport"))
            {
                AllTickets = TicketService.GetAllTickets("office");
            }
            else if (CurrentUser.IsAssignedToRole("TechSupport"))
            {
                AllTickets = TicketService.GetAllTickets("tech");
            }
            else
            {
                AllTickets = TicketService.GetAllTickets();
            }
        }

    }

}
