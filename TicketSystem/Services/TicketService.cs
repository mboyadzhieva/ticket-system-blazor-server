namespace TicketSystem.Services
{
    using AutoMapper;
    using System.Linq;
    using System.Collections.Generic;
    using TicketSystem.Data;
    using TicketSystem.Models;
    using Microsoft.Extensions.Logging;
    using System;

    public class TicketService : ITicketService
    {
        private ApplicationDbContext DbContext { get; set; }

        private IMapper Mapper { get; set; }

        private ILogger<TicketService> Logger { get; set; }

        public TicketService(ApplicationDbContext dbContext, IMapper mapper, ILogger<TicketService> logger) 
        {
            this.DbContext = dbContext;
            this.Mapper = mapper;
            this.Logger = logger;
        }

        public void AddTicket(TicketModel ticket)
        {
            throw new System.NotImplementedException();
        }

        public List<TicketModel> GetAllTickets()
        {
            List<TicketModel> result;

            try
            {
                result = DbContext.Tickets.Select(t => Mapper.Map<TicketModel>(t)).ToList();
                return result;
            }
            catch(Exception e)
            {
                Logger.LogError(e, "Error in GetAllTickets in TicketService");
                throw;
            }
        }

        public TicketModel GetTicketById(int id)
        {
            TicketModel result;

            try
            {
                result = DbContext
                    .Tickets
                    .Select(t => Mapper.Map<TicketModel>(t)).FirstOrDefault(t => t.Id == id);

                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error in GetTicketById in TicketService");
                throw;
            }
        }
    }
}
