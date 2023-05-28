using MC.Domain;
using MC.Services.DTOs;
using MC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _movieService;

        public MoviesController(IMoviesService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(Guid id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie([FromBody] CreateMovieDto movieDto)
        {
            var movie = await _movieService.AddMovieAsync(movieDto);
            return Created($"/movies/{movie.Id}", movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie([FromRoute] Guid id, [FromBody] EditMovieDto movieDto)
        {
            var movie = await _movieService.UpdateMovieAsync(id, movieDto);
            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            await _movieService.DeleteMovieAsync(id);
            return Ok();
        }
    }
}
