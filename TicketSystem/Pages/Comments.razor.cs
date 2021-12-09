using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSystem.Data.Models;
using TicketSystem.Models;
using TicketSystem.Services;

namespace TicketSystem.Pages
{
    public partial class Comments
    {
        private List<CommentModel> AllComments{ get; set; }

        public string Username { get; set; }

        [Inject]
        private UserManager<ApplicationUser> UserManager { get; set; }

        [Inject]
        private ICommentService CommentService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }


        [Parameter]
        public string TicketId { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            // Username = UserManager.FindByIdAsync()
            AllComments = CommentService.GetAllComments(int.Parse(TicketId));
        }
    }
}
