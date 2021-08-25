using Microsoft.EntityFrameworkCore;
using Quotes.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quotes.Infrastructure
{
    public class QuoteContext : DbContext
    {
        public QuoteContext(DbContextOptions<QuoteContext> options) : base(options)
        {

        }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
