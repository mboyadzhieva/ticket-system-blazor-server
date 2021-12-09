namespace TicketSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CommentModel
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Comment content cannot be shorter than 4 charecters.")]
        [MaxLength(2000, ErrorMessage = "Comment content cannot be longer than 2000 charecters.")]
        public string Content { get; set; }

        public string PhotoId { get; set; }

        public int TicketId { get; set; }
    }
}
