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
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorsService _directorsService;

        public DirectorsController(IDirectorsService directorsService)
        {
            _directorsService = directorsService;
        }

        [HttpGet]
        public async Task<ActionResult<Director>> GetAllDirectors()
        {
            var directors = await _directorsService.GetAllDirectorAsync();
            return Ok(directors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Director>> GetDirectorById([FromRoute] Guid id)
        {
            var director = await _directorsService.GetDirectorByIdAsync(id);
            return Ok(director);
        }

        [HttpPost]
        public async Task<ActionResult<Director>> AddDirector([FromBody] CreateDirectorDto directorDto)
        {
            var director = await _directorsService.AddDirectorAsync(directorDto);
            return Created($"/directors/{director.Id}", director);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDirector([FromRoute] Guid id, [FromBody] EditDirectorDto directorDto)
        {
            var director = await _directorsService.UpdateDirectorAsync(id, directorDto);
            return Ok(director);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirector(Guid id)
        {
            await _directorsService.DeleteDirectorAsync(id);
            return Ok();
        }
    }
}