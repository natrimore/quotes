using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Quotes.Domain
{
    public class Quote
    {
        [Key]
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string QuoteName { get; set; }
        public string Category { get; set; }
        public DateTime Created { get; set; }
    }
}
