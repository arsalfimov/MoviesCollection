using MC.Domain;
using MC.Services.DTOs;

namespace MC.Services.Interfaces
{
    public interface IActorsService
    {
        Task<List<Actor>> GetAllActorAsync();
        Task<Actor> GetActorByIdAsync(Guid id);
        Task<Actor> AddActorAsync(CreateActorDto actorDto);
        Task<Actor> UpdateActorAsync(Guid id, EditActorDto actorDto);
        Task DeleteActorAsync(Guid id);
    }
}
