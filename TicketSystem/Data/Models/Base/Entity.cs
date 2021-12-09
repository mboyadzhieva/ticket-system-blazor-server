namespace TicketSystem.Data.Models.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Entity : IEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string PhotoId { get; set; }

        // created by
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
