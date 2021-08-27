using System;
using System.Collections.Generic;
using System.Text;

namespace Quotes.Shared.Types
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int Total { get; set; }
    }
}
