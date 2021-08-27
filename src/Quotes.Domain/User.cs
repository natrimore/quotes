using System;
using System.Collections.Generic;
using System.Text;

namespace Quotes.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsSubscribed { get; set; }
    }
}
