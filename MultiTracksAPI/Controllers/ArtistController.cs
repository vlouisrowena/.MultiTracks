using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiTracksAPI.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace MultiTracksAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class artistController : Controller
    {
        private readonly MultiTracksDBContext _dbContext;

        public artistController(MultiTracksDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("search")]
        public async Task<ActionResult<string>> Search (string artistTitle)
        {

            var artistsList = await (from artist in _dbContext.Artist
                                        where artist.Title.Contains(artistTitle)
                                        select artist).ToListAsync();
            return Ok(artistsList);
        }


        [HttpPost("add")]
        public async Task<ActionResult<Artist>> Add(Artist artist )
        {
           _dbContext.Artist.Add (artist);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Search), new { ar = artist.Title }, artist);
        }

    }
}
