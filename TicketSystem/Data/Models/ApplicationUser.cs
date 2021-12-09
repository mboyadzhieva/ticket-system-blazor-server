namespace TicketSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
