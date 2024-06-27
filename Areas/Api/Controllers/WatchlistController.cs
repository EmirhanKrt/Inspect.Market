using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inspect.Market.Context;
using Inspect.Market.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Inspect.Market.Areas.Api.Models.DTO;

namespace Inspect.Market.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WatchlistController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WatchlistController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Api/Watchlist
        [HttpGet]
        public async Task<IActionResult> GetWatchlists()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var watchlists = await _context.Watchlists
                .Where(w => w.UserId == userId)
                .Select(w => new
                {
                    w.Id,
                    w.UserId,
                    w.CryptocurrencyId
                })
                .ToListAsync();

            return Ok(watchlists);
        }


        // GET: Api/Watchlist/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWatchlist(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var watchlist = await _context.Watchlists
                .Select(w => new
                {
                    w.Id,
                    w.UserId,
                    w.CryptocurrencyId
                })
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);

            if (watchlist == null)
            {
                return NotFound();
            }

            return Ok(watchlist);
        }

        // POST: Api/Watchlists
        [HttpPost]
        public async Task<IActionResult> CreateWatchlist([FromBody] WatchlistDto watchlistDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cryptocurrencyExists = await _context.Cryptocurrencies
                .AnyAsync(c => c.Id == watchlistDto.CryptocurrencyId);

            if (!cryptocurrencyExists)
            {
                return BadRequest("Invalid CryptocurrencyId.");
            }

            var watchlistExists = await _context.Watchlists
                .AnyAsync(w => w.UserId == userId && w.CryptocurrencyId == watchlistDto.CryptocurrencyId);

            if (watchlistExists)
            {
                return Conflict("Watchlist already exists for this user and cryptocurrency.");
            }

            var watchlist = new Watchlist
            {
                UserId = userId,
                CryptocurrencyId = watchlistDto.CryptocurrencyId
            };

            _context.Watchlists.Add(watchlist);
            await _context.SaveChangesAsync();

            var result = new
            {
                Id = watchlist.Id,
                UserId = watchlist.UserId,
                CryptocurrencyId = watchlist.CryptocurrencyId
            };

            return CreatedAtAction(nameof(GetWatchlist), new { id = watchlist.Id }, result);
        }

        // DELETE: Api/Watchlists/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWatchlist(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var watchlist = await _context.Watchlists
                .Where(w => w.Id == id && w.UserId == userId)
                .FirstOrDefaultAsync();

            if (watchlist == null)
            {
                return NotFound();
            }

            _context.Watchlists.Remove(watchlist);
            await _context.SaveChangesAsync();

            var result = new
            {
                Id = watchlist.Id,
                UserId = watchlist.UserId,
                CryptocurrencyId = watchlist.CryptocurrencyId
            };

            return Ok(result);
        }
    }
}
