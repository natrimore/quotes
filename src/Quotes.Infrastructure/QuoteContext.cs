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
            LoadUsers();
        }

        public List<Quote> Quotes { get; set; }
        public List<User> Users { get; set; }

        private void LoadQuotes()
        {
            var quotes = new List<Quote>()
            {
                new Quote
                {
                    Author = "author",
                    Category = "category",
                    Created = DateTime.Now,
                    QuoteName = "go on",
                    Id = Guid.NewGuid()
                },
                new Quote
                {
                    Author = "author2",
                    Category = "category2",
                    Created = DateTime.Now.AddHours(-24),
                    QuoteName = "keep calm",
                    Id = Guid.NewGuid()
                }
            };

            Quotes.AddRange(quotes);
        }

        private void LoadUsers()
        {
            var users = new List<User>()
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "example@example.com",
                    IsSubscribed = true,
                    UserName = "example@example.com"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "test@test.com",
                    IsSubscribed = true,
                    UserName = "test@test.com"
                }
            };

            Users.AddRange(users);
        }
    }

    
}
