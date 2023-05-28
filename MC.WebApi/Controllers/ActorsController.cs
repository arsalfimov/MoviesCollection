using MC.Domain;
using MC.Services;
using MC.Services.DTOs;
using MC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorsService _actorsService;

        public ActorsController(IActorsService actorsService)
        {
            _actorsService = actorsService;
        }

        [HttpGet]
        public async Task<ActionResult<Actor>> GetAllActors()
        {
            var actors = await _actorsService.GetAllActorAsync();
            return Ok(actors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActorById([FromRoute] Guid id)
        {
            var actor = await _actorsService.GetActorByIdAsync(id);
            return Ok(actor);
        }

        [HttpPost]
        public async Task<ActionResult<Actor>> AddActor([FromBody] CreateActorDto actorDto)
        {
            var actor = await _actorsService.AddActorAsync(actorDto);
            return Created($"/directors/{actor.Id}", actor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActor([FromRoute] Guid id, [FromBody] EditActorDto actorDto)
        {
            var actor = await _actorsService.UpdateActorAsync(id, actorDto);
            return Ok(actor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(Guid id)
        {
            await _actorsService.DeleteActorAsync(id);
            return Ok();
        }
    }
}
