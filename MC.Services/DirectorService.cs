using AutoMapper;
using MC.Domain;
using MC.PersistanceInterfaces;
using MC.Services.DTOs;
using MC.Services.Interfaces;

namespace MC.Services
{
    public class DirectorService : IDirectorsService
    {
        private readonly IRepository<Director, Guid> _directorRepository;
        private readonly IMapper _mapper;

        public DirectorService(IRepository<Director, Guid> repository, IMapper mapper)
        {
            _directorRepository = repository;
            _mapper = mapper;
        }

        public async Task<List<Director>> GetAllDirectorAsync()
        {
            return await _directorRepository.GetAllAsync();
        }

        public async Task<Director> GetDirectorByIdAsync(Guid id)
        {
            return await _directorRepository.GetByIdAsync(id);
        }

        public async Task<Director> AddDirectorAsync(CreateDirectorDto directorDto)
        {
            var director = _mapper.Map<Director>(directorDto);
            await _directorRepository.AddAsync(director);
            return director;
        }

        public async Task<Director> UpdateDirectorAsync(Guid id, EditDirectorDto directorDto)
        {
            var director = await GetDirectorByIdAsync(id);

            director.Name = directorDto.Name;
            director.Surname = directorDto.Surname;
            director.Patr = directorDto.Patr;

            await _directorRepository.UpdateAsync(director);
            return director;
        }

        public async Task DeleteDirectorAsync(Guid id)
        {
            await _directorRepository.DeleteAsync(id);
        }
    }
}