namespace TicketSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TicketSystem.Data.Models;

    public class TicketModel
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Title cannot be shorter than 3 charecters.")]
        [MaxLength(50, ErrorMessage = "Title cannot be longer than 200 charecters.")]
        public string Title { get; set; }

        [MinLength(4, ErrorMessage = "Comment content cannot be shorter than 4 charecters.")]
        [MaxLength(200, ErrorMessage = "Comment content cannot be longer than 200 charecters.")]
        public string Content { get; set; }

        public int PhotoId { get; set; }

        public bool IsPrivate { get; set; }

        public SupportType AssignedTo { get; set; }

        public ICollection<CommentModel> Comments { get; set; }
    }
}
