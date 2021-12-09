namespace TicketSystem.Services
{
    using AutoMapper;
    using System.Linq;
    using System.Collections.Generic;
    using TicketSystem.Data;
    using TicketSystem.Models;
    using Microsoft.Extensions.Logging;
    using System;
    using TicketSystem.Data.Models;

    public class TicketService : ITicketService
    {
        private ApplicationDbContext DbContext { get; set; }

        private IMapper Mapper { get; set; }

        private ILogger<TicketService> Logger { get; set; }

        private ICurrentUserService CurrentUser { get; set; }

        public TicketService(ApplicationDbContext dbContext, IMapper mapper, ILogger<TicketService> logger, ICurrentUserService currentUser)
        {
            this.DbContext = dbContext;
            this.Mapper = mapper;
            this.Logger = logger;
            this.CurrentUser = currentUser;
        }

        public void AddTicket(TicketModel ticket)
        {
            try
            {
                Ticket result = Mapper.Map<Ticket>(ticket);
                DbContext.Tickets.Add(result);
                DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error in AddTicket in TicketService");
                throw;
            }
        }

        public List<TicketModel> GetAllTickets(string role = "all")
        {
            List<TicketModel> result = new();
            string userId = CurrentUser.GetId();

            try
            {
                if (role.Equals("all"))
                {
                    result = DbContext.Tickets
                        .Select(t => Mapper.Map<TicketModel>(t))
                        .ToList()
                        .Where(t => t.IsPrivate.Equals(false) || t.UserId.Equals(userId))
                        .ToList();
                }
                else if (role.Equals("office"))
                {
                    result = DbContext.Tickets
                        .Select(t => Mapper.Map<TicketModel>(t))
                        .ToList()
                        .Where(t => t.AssignedTo.Equals(SupportType.Office) && t.IsPrivate.Equals(false))
                        .ToList();
                }
                else if (role.Equals("tech"))
                {
                    result = DbContext.Tickets
                        .Select(t => Mapper.Map<TicketModel>(t))
                        .ToList()
                        .Where(t => t.AssignedTo.Equals(SupportType.Tech) && t.IsPrivate.Equals(false))
                        .ToList();
                }

                return result;
            }
            catch (Exception e)
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
