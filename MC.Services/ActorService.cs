using AutoMapper;
using MC.Domain;
using MC.PersistanceInterfaces;
using MC.Services.DTOs;
using MC.Services.Interfaces;

namespace MC.Services
{
    public class ActorService : IActorsService
    {
        private readonly IRepository<Actor, Guid> _actorRepository;
        private readonly IMapper _mapper;

        public ActorService(IRepository<Actor, Guid> repository, IMapper mapper)
        {
            _actorRepository = repository;
            _mapper = mapper;
        }

        public async Task<List<Actor>> GetAllActorAsync()
        {
            return await _actorRepository.GetAllAsync();
        }

        public async Task<Actor> GetActorByIdAsync(Guid id)
        {
            return await _actorRepository.GetByIdAsync(id);
        }

        public async Task<Actor> AddActorAsync(CreateActorDto actorDto)
        {
            var actor = _mapper.Map<Actor>(actorDto);
            await _actorRepository.AddAsync(actor);
            return actor;
        }

        public async Task<Actor> UpdateActorAsync(Guid id, EditActorDto actorDto)
        {
            var actor = await GetActorByIdAsync(id);

            actor.Name = actorDto.Name;
            actor.Surname = actorDto.Surname;
            actor.Patr = actorDto.Patr;

            await _actorRepository.UpdateAsync(actor);
            return actor;
        }

        public async Task DeleteActorAsync(Guid id)
        {
            await _actorRepository.DeleteAsync(id);
        }
    }
}
