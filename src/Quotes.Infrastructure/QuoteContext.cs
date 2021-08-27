using Microsoft.EntityFrameworkCore;
using Quotes.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quotes.Infrastructure
{
    public class QuoteContext
    {
        public QuoteContext()
        {
            Quotes = new List<Quote>();
            Users = new List<User>();
            LoadQuotes();
        }

        public List<Quote> Quotes { get; set; }
        public List<User> Users { get; set; }

        public void LoadQuotes()
        {
            Quote quote = new Quote
            {
                Author = "1",
                Category = "2",
                Created = DateTime.Now,
                QuoteName = "bir narsalar",
                Id = Guid.NewGuid()
            };

            Quotes.Add(quote);
        }
    }

    
}
