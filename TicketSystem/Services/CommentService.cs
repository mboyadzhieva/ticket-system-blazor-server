namespace TicketSystem.Services
{
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TicketSystem.Data;
    using TicketSystem.Data.Models;
    using TicketSystem.Models;

    public class CommentService : ICommentService
    {
        private ApplicationDbContext DbContext { get; set; }

        private IMapper Mapper { get; set; }

        private ILogger<CommentService> Logger { get; set; }

        public CommentService(ApplicationDbContext dbContext, IMapper mapper, ILogger<CommentService> logger)
        {
            this.DbContext = dbContext;
            this.Mapper = mapper;
            this.Logger = logger;
        }

        public void AddComment(CommentModel comment, int ticketId)
        {
            try
            {
                Comment result = Mapper.Map<Comment>(comment);

                Ticket ticket = DbContext.Tickets.Where(t => t.Id == ticketId).First();
                //ICollection<Comment> ticketComments = ticket.Comments;
                //ticketComments.Add(result);
                ticket.Comments.Add(result);

                DbContext.Comments.Add(result);
                DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error in AddComment in CommentService");
                throw;
            }
        }

        public List<CommentModel> GetAllComments(int ticketId)
        {
            List<CommentModel> result;

            try
            {
                result = DbContext.Comments.Select(c => Mapper.Map<CommentModel>(c)).ToList().Where(c => c.TicketId == ticketId).ToList();
                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error in GetAllComments in CommentService");
                throw;
            }
        }

        public CommentModel GetCommentById(int id)
        {
            CommentModel result;

            try
            {
                result = DbContext
                    .Comments
                    .Select(c => Mapper.Map<CommentModel>(c)).FirstOrDefault(c => c.Id == id);

                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error in GetCommentById in CommentService");
                throw;
            }
        }
    }
}
