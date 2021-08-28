using Hangfire;
using Quotes.Infrastructure.Repository;
using Quotes.Shared.Messaging;
using System;
using System.Collections.Generic;

namespace Quotes.API.Helpers
{
    public class BackgroundJobInitializer
    {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;
        private readonly IQuoteRepository _quoteRepository;
        public BackgroundJobInitializer(IEmailService emailService, IUserRepository userRepository, IQuoteRepository quoteRepository)
        {
            _emailService = emailService ??
                throw new ArgumentNullException(nameof(emailService));

            _userRepository = userRepository ??
                throw new ArgumentNullException(nameof(userRepository));

            _quoteRepository = quoteRepository ??
                throw new ArgumentNullException(nameof(quoteRepository));
        }

        public void InitializeJob()
        {
            var deleteQuoteCronExpression = "*/5 * * * *";
            RecurringJob.AddOrUpdate(() => DeleteQuote(), deleteQuoteCronExpression);

            var subscribeCronExpression = "0 0 8 * * ?";
            RecurringJob.AddOrUpdate(() => Subscribe(), subscribeCronExpression);
        }

        public void DeleteQuote()
        {
            Console.Write("--- Delete quote worker ---");
            var entities = _quoteRepository.FindAllAsync();
            var outdatedQuotes = new List<Domain.Quote>();

            var outDated = DateTime.Now.AddHours(-24);
            entities.ForEach(f =>
            {
                if (f.Created < outDated)
                {
                    Console.WriteLine($"Deleted: {f.QuoteName} with date: {f.Created}");
                    outdatedQuotes.Add(f);
                }
            });

            _quoteRepository.RemoveRange(outdatedQuotes);
        }

        public void Subscribe()
        {
            Console.WriteLine("--- Send SMS to subscribed users ---");

            var users = _userRepository.GetAll();

            foreach (var user in users)
            {
                if (user.IsSubscribed)
                {
                    var quote = _quoteRepository.GetRandomQuote();
                    _emailService.SendAsync(user.Email, $"quote: {quote.QuoteName}");
                }
            }
        }
    }
}
