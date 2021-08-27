namespace Quotes.Shared.Messaging
{
    public interface IEmailService
    {
        void SendAsync(string email, string body);
    }
}
