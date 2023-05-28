using AutoMapper;
using MC.Domain;
using MC.PersistanceInterfaces;
using MC.Services.DTOs;
using MC.Services.Interfaces;

namespace MC.Services
{
    public class MoviesActorsService : IMoviesActorsService
    {
        private readonly IRepository<MoviesActors, Guid> _movieRepository;
        private readonly IGetEnumerable<MoviesActors, Guid> _getEnumerableRepository;
        private readonly IMapper _mapper;

        public MoviesActorsService(IRepository<MoviesActors, Guid> repository, IGetEnumerable<MoviesActors, Guid> getEnumerableRepository, IMapper mapper)
        {
            _movieRepository = repository;
            _getEnumerableRepository = getEnumerableRepository;
            _mapper = mapper;
        }

        public async Task<List<MoviesActors>> GetAllMoviesActorsAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<MoviesActors> GetMoviesActorsByIdAsync(Guid id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<MoviesActors> AddMoviesActorsAsync(CreateMoviesActorsDto moviesActorsDto)
        {
            var movieActors = _mapper.Map<MoviesActors>(moviesActorsDto);
            return await _movieRepository.AddAsync(movieActors);
        }

        //public async Task<MoviesActors> UpdateMoviesActorsAsync(Guid id, MoviesActors moviesActors)
        //{
        //    var movie = await GetMoviesActorsByIdAsync(id);

        //    movie.ActorId = moviesActors.ActorId;

        //    await _movieRepository.UpdateAsync(movie);
        //    return movie;
        //}

        public async Task DeleteMoviesActorsAsync(Guid id)
        {
            await _movieRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<MoviesActors>> GetRangeById(Guid id)
        {
            return await _getEnumerableRepository.GetRangeById(id);
        }
    }
}
