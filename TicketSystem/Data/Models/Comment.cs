namespace TicketSystem.Data.Models
{
    using Base;
    using System.ComponentModel.DataAnnotations;

    public class Comment : Entity
    {
        [Required]
        [MaxLength(2000)]
        public string Content { get; set; }

        [Required]
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
