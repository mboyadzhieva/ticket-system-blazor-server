namespace TicketSystem.Pages
{
    using Microsoft.AspNetCore.Components;
    using TicketSystem.Models;

    public partial class CommentSection
    {
        [Parameter]
        public CommentModel Comment { get; set; }
    }
}
