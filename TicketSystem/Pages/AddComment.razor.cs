namespace TicketSystem.Pages
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Logging;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using TicketSystem.Models;
    using TicketSystem.Services;

    public partial class AddComment
    {

        [Parameter]
        public string TicketId { get; set; }

        [Inject]
        public ICommentService CommentService { get; set; }

        [Inject]
        public IWebHostEnvironment Environment { get; set; }

        [Inject]
        public ICurrentUserService CurrentUser { get; set; }

        [Inject]
        public ILogger<AddComment> Logger { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IBrowserFile Photo { get; set; }

        public CommentModel CommentModel { get; set; } = new CommentModel();

        private string ErrorMsg = string.Empty;

        public async Task CreateComment()
        {
            try
            {
                if (Photo != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    string wwwrootpath = Environment.WebRootPath;
                    string extension = Path.GetExtension(Photo.Name);
                    string newFilePath = Path.Combine(wwwrootpath, "Uploads", fileName + extension);
                    using FileStream fileStream = new FileStream(newFilePath, FileMode.Create);
                    await Photo.OpenReadStream().CopyToAsync(fileStream);

                    CommentModel.PhotoId = fileName + extension;
                }

                CommentService.AddComment(CommentModel, int.Parse(TicketId));
                NavigationManager.NavigateTo($"/comments/{TicketId}");
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error in CreateComment() in AddComment.razor.cs");
                ErrorMsg = e.Message;
            }

        }

        private void OnFileSubmit(InputFileChangeEventArgs e)
        {
            if (e.FileCount > 0)
            {
                Photo = e.File;
            }
        }
    }
}
