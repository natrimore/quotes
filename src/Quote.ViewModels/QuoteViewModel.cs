using System;
using System.Collections.Generic;
using System.Text;

namespace Quote.ViewModels
{
    public class QuoteViewModel
    {
        public Guid Id { get; set; }
        public string QuoteName { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime Created { get; set; }
    }
}
