namespace TicketSystem.Data.Models
{
    using Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Ticket : Entity
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Content { get; set; }

        public int PhotoId { get; set; }

        public bool IsPrivate { get; set; }

        public SupportType AssignedTo { get; set; }

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
