using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quote.ViewModels;
using Quotes.API.Commands;
using Quotes.API.Queries;
using Quotes.Shared.Dispatchers;
using Quotes.Shared.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public UsersController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher ??
                throw new ArgumentNullException(nameof(dispatcher));
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<UserViewModel>>> GetAllAsync()
        {
            var query = new GetUsers();
            var result = await _dispatcher.QueryAsync(query);

            return Ok(result);
        }

        /// <summary>
        /// Subscribe or unsubscribe for daily quotes
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync(SubscribeUser command)
        {
            await _dispatcher.SendAsync(command);

            return Ok();
        }
    }
}
