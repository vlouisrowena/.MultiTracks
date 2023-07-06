using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiTracksAPI.Models;


namespace MultiTracksAPI.Controllers
{
    [Route("song")]
    [ApiController]
    public class SongController : Controller
    {
        private readonly MultiTracksDBContext _dbContext;

        public SongController(MultiTracksDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet("list")]

        public async Task<IActionResult> SongList([FromQuery] PageParams songParams)
        {
            var songs = await (from song in _dbContext.Song

                             select song.Title

                             ).Skip((songParams.pageNumber - 1) * songParams.PageSize)
                              .Take(songParams.PageSize)
                              .ToListAsync();
            return Ok(songs);
        }
    }

}
