using System;
using System.Collections.Generic;
using System.Text;

namespace Quote.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsSubscribed { get; set; }

    }
}
