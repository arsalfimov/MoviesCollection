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
        public async Task<ActionResult<List<Movie>>> GetAllMovies(BrowseMovieDto dto)
        {

            var movies = await _movieService.GetAllMoviesAsync(dto);
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

        [HttpDelete("{id}/remove")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            await _movieService.DeleteMovieAsync(id);
            return Ok();
        }

        [HttpDelete("{movieId}/actor/{actorId}/remove")]
        public async Task<IActionResult> RemoveMovieActor(Guid movieId, Guid actorId)
        {
            await _movieService.RemoveMovieActorAsync(movieId, actorId);
            return Ok();
        }

        [HttpDelete("/{movieId}/actors/remove")]
        public async Task<IActionResult> RemoveMovieActors(Guid movieId, [FromBody] List<Guid> actorIds)
        {
            try
            {
                await _movieService.RemoveMovieActorsAsync(movieId, actorIds);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
