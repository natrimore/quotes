using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quotes.Shared.Dispatchers
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
