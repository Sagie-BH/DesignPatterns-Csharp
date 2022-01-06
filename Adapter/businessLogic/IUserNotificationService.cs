namespace Adapter.businessLogic
{
    public interface IUserNotificationService
    {
        Task NotifyUser(string userId, string message);
    }
}
