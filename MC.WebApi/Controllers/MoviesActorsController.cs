using MC.Domain;
using MC.Services.DTOs;
using MC.Services;
using MC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class MoviesActorsController : ControllerBase
    {
        private readonly IMoviesActorsService _moviesActorsService;

        public MoviesActorsController(IMoviesActorsService movieActorsService)
        {
            _moviesActorsService = movieActorsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MoviesActors>>> GetAllMoviesActors()
        {
            var movies = await _moviesActorsService.GetAllMoviesActorsAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<MoviesActors>>> GetRangeById(Guid id)
        {
            return Ok(await _moviesActorsService.GetRangeById(id));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<MoviesActors>> GetMoviesActorsById(Guid id)
        {
            var movie = await _moviesActorsService.GetMoviesActorsByIdAsync(id);
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<MoviesActors>> AddMoviesActors([FromBody] CreateMoviesActorsDto movieActorsDto)
        {
            var movieActors = await _moviesActorsService.AddMoviesActorsAsync(movieActorsDto);
            return Created($"/moviesActors/{movieActors.MovieId}", movieActors);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateMoviesActors([FromRoute] Guid id, [FromBody] MoviesActors movieActors)
        //{
        //    var movie = await _moviesActorsService.UpdateMoviesActorsAsync(id, movieActors);
        //    return Ok(movie);
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            await _moviesActorsService.DeleteMoviesActorsAsync(id);
            return Ok();
        }

        

    }
}
