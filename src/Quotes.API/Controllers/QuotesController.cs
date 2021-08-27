using Microsoft.AspNetCore.Mvc;
using Quote.ViewModels;
using Quotes.API.Commands;
using Quotes.API.Queries;
using Quotes.Infrastructure;
using Quotes.Shared.Dispatchers;
using Quotes.Shared.Types;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.API.Controllers
{
    [Route("api/quote")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;
        public QuotesController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher ??
                throw new ArgumentNullException(nameof(dispatcher));

        }

        /// <summary>
        /// Get all quotes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PagedResult<QuoteViewModel>>> GetAllAsync()
        {
            var query = new GetQuotes();
            var response = await _dispatcher.QueryAsync(query);
            return Ok(response);
        }

        /// <summary>
        /// Get by category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet("{category}")]
        public async Task<ActionResult<PagedResult<QuoteViewModel>>> GetByCategoryASync(string category)
        {
            GetQuotesByCategory query = new GetQuotesByCategory { Category = category };
            var entities = await _dispatcher.QueryAsync(query);
            return Ok(entities);
        }

        /// <summary>
        /// Get random quote
        /// </summary>
        /// <returns></returns>
        [HttpGet("random")]
        public async Task<ActionResult<QuoteViewModel>> GetRandomAsync()
        {
            var query = new GetRandomQuote();
            var entity = _dispatcher.QueryAsync(query);
            return Ok(entity);
        }

        /// <summary>
        /// Create new quote
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateQuote command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _dispatcher.SendAsync(command);
            return Ok();
        }

        /// <summary>
        /// Update quote
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] UpdateQuote command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _dispatcher.SendAsync(command);
            return Ok();
        }

        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            DeleteQuote command = new DeleteQuote { Id = id };
            await _dispatcher.SendAsync(command);
            return NoContent();
        }
    }
}
