using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiTracksAPI.Models;

namespace MultiTracksAPI.Controllers
{
    public class ArtistController : Controller
    {
        private readonly MultiTracksDBContext _dbContext;

        public ArtistController(MultiTracksDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("api/artist/search")]
        public async Task<ActionResult<string>> Search (string artistTitle)
        {
            try
            {
                var artistsList = await (from artist in _dbContext.Artist
                                         where artist.Title.Contains(artistTitle)
                                         select artist).ToListAsync();
                return Ok(artistsList);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }

        }


        [HttpPost]
        [Route("api/artist/add")]
        public async Task<ActionResult<Artist>> Add(Artist artist )
        {
           _dbContext.Artist.Add (artist);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Search), new { ar = artist.Title }, artist);
        }

    }
}
