namespace TicketSystem.Pages
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using TicketSystem.Data.Models;
    using TicketSystem.Models;
    using TicketSystem.Services;

    public partial class TicketCard
    {
        [Parameter]
        public TicketModel Ticket { get; set; }

        [Inject]
        private UserManager<ApplicationUser> UserManager { get; set; }

        public string Username { get; set; }

        //protected override async Task OnInitializedAsync()
        //{
        //    ApplicationUser ticketOwner = await UserManager.FindByIdAsync(Ticket.UserId);
        //    Username = ticketOwner.UserName;
        //}

    }
}
