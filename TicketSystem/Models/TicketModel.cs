namespace TicketSystem.Models
{
    using System.Collections.Generic;

    public class TicketModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsPrivate { get; set; }
        public int AssignedTo { get; set; }
        public string UserId { get; set; }

        // ? public IEnumerable<CommentModel> Comments { get; set; }
    }
}
