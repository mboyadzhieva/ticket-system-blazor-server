namespace TicketSystem.Services
{
    public interface ICurrentUserService
    {
        string GetUserName();

        string GetId();

        bool IsAssignedToRole(string role);
    }
}
