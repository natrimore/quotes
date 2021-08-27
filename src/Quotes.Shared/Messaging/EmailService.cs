using System;

namespace Quotes.Shared.Messaging
{
    public class EmailService : IEmailService
    {
        public void SendAsync(string email, string body)
        {
            Console.WriteLine($"Sent to email: {email}. Body: {body} ");
        }
    }
}
