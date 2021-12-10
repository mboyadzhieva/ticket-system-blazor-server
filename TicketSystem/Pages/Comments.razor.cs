namespace TicketSystem.Pages
{
    using Microsoft.AspNetCore.Components;
    using System.Collections.Generic;
    using TicketSystem.Models;
    using TicketSystem.Services;

    public partial class Comments
    {
        private List<CommentModel> AllComments{ get; set; }

        public string Username { get; set; }

        [Inject]
        private ICommentService CommentService { get; set; }

        [Parameter]
        public string TicketId { get; set; }
 
        protected override void OnInitialized()
        {
            base.OnInitialized();

            AllComments = CommentService.GetAllComments(int.Parse(TicketId));
        }
    }
}
