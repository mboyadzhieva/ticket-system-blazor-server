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

        public string UserId { get; set; }

        [Required]
        [Display(Name = "Title")]
        [MinLength(3, ErrorMessage = "Title cannot be shorter than 3 charecters.")]
        [MaxLength(50, ErrorMessage = "Title cannot be longer than 200 charecters.")]
        public string Title { get; set; }

        [Display(Name = "Content")]
        [MinLength(4, ErrorMessage = "Comment content cannot be shorter than 4 charecters.")]
        [MaxLength(2000, ErrorMessage = "Comment content cannot be longer than 2000 charecters.")]
        public string Content { get; set; }

        [Display(Name = "Photo")]
        public string PhotoId { get; set; }

        [Display(Name = "Make private")]
        public bool IsPrivate { get; set; }

        [Required]
        [Display(Name = "Support type")]
        public SupportType AssignedTo { get; set; }

        public ICollection<CommentModel> Comments { get; set; } = new HashSet<CommentModel>();
    }
}
