using System;
using System.Collections.Generic;
using System.Text;

namespace Quotes.Shared.Dispatchers
{
    public interface IQuery
    {
    }

    public interface IQuery<T> : IQuery
    {

    }
}
