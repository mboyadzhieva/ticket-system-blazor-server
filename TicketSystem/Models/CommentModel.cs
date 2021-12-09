namespace TicketSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CommentModel
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Comment content cannot be shorter than 4 charecters.")]
        [MaxLength(4, ErrorMessage = "Comment content cannot be longer than 200 charecters.")]
        public string Content { get; set; }

        public int PhotoId { get; set; }

        [Required]
        public int TicketId { get; set; }
    }
}
