namespace TicketSystem.Data.Models.Base
{
    using System;

    interface IEntity
    {
        int Id { get; set; }

        DateTime CreatedOn { get; set; }

        string UserId { get; set; }

        ApplicationUser User { get; set; }
    }
}
