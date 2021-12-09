namespace TicketSystem.Services
{
    using Models;
    using System.Collections.Generic;

    public interface ITicketService
    {
        List<TicketModel> GetAllTickets(string role = "all");

        TicketModel GetTicketById(int id);

        void AddTicket(TicketModel ticket);
    }
}
