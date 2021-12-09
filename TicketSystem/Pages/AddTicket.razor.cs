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

    public partial class AddTicket
    {
        [Inject]
        public ITicketService TicketService { get; set; }

        [Inject]
        public IWebHostEnvironment Environment { get; set; }

        [Inject]
        public ICurrentUserService CurrentUser { get; set; }

        [Inject]
        public ILogger<AddTicket> Logger { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IBrowserFile Photo { get; set; }

        public TicketModel TicketModel { get; set; } = new TicketModel();

        private string ErrorMsg = string.Empty;

        public async Task CreateTicket()
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

                    TicketModel.PhotoId = fileName + extension;
                }

                TicketService.AddTicket(TicketModel);
                NavigationManager.NavigateTo("/tickets");
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error in CreateTicket() in AddTicket.razor");
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
