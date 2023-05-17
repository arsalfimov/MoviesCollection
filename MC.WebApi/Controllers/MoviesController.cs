using MC.Domain;
using MC.Services.DTOs;
using MC.Services.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace MC.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            try
            {
                var movies = await _movieService.GetAllMoviesAsync();
                if (movies.Count == 0)
                {
                    return NotFound();
                }
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(Guid id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie([FromBody] Movie movie)
        {
            var addedMovie = await _movieService.AddMovieAsync(movie);
            return Ok(addedMovie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            try
            {
                await _movieService.DeleteMovieAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie([FromRoute] Guid id, [FromBody] EditMovieDto movie)
        {

            var result = await _movieService.UpdateMovieAsync(id, movie);
            return Ok(result);
        }
    }
}
