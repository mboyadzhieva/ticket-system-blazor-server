namespace TicketSystem.Services
{
    using System.Collections.Generic;
    using TicketSystem.Models;

    public interface ICommentService
    {
        List<CommentModel> GetAllComments(int ticketId);

        CommentModel GetCommentById(int id);

        void AddComment(CommentModel comment, int ticketId);
    }
}
