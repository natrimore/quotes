using System;
using System.Collections.Generic;
using System.Text;

namespace Quotes.Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string QuoteName { get; set; }
        public string Category { get; set; }
    }
}
