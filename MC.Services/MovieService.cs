using AutoMapper;
using MC.Domain;
using MC.PersistanceInterfaces;
using MC.Services.DTOs;
using MC.Services.Interfaces;

namespace MC.Services
{
    public class MovieService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;

        public MovieService(IMoviesRepository moviesRepository, IMapper mapper)
        {
            _moviesRepository = moviesRepository;
            _mapper = mapper;
        }

        public async Task<List<Movie>> GetAllMoviesAsync(BrowseMovieDto dto)
        {
            return await _moviesRepository.GetAllAsync(dto.OrderBy);
        }

        public async Task<Movie> GetMovieByIdAsync(Guid id)
        {
            return await _moviesRepository.GetByIdAsync(id);
        }

        public async Task<Movie> AddMovieAsync(CreateMovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            movie.Actors.AddRange(movieDto.Actors.Select(a => new MoviesActors() { ActorId = a}).ToList());

            movie.Rates = _mapper.Map<List<MoviesRates>>(movieDto.Rates);

            await _moviesRepository.AddAsync(movie);
            movie = await GetMovieByIdAsync(movie.Id);
            return movie; 
        }

        public async Task<Movie> UpdateMovieAsync(Guid id, EditMovieDto movieDto)
        {
            var movie = await GetMovieByIdAsync(id);

            movie.Title = movieDto.Title;
            movie.Description = movieDto.Description;
            movie.DirectorId = movieDto.DirectorId;
            movie.Actors = movieDto.Actors.Select(a => new MoviesActors() { ActorId = a }).ToList();

            await _moviesRepository.UpdateAsync(movie);
            return movie;
        }

        public async Task DeleteMovieAsync(Guid id)
        {
            await _moviesRepository.DeleteAsync(id);
        }

        public async Task RemoveMovieActorAsync(Guid movieId, Guid actorId)
        {
            await _moviesRepository.RemoveMovieActorAsync(movieId, actorId);
        }

        public async Task RemoveMovieActorsAsync(Guid movieId, List<Guid> actorId)
        {
            await _moviesRepository.RemoveMovieActorsAsync(movieId, actorId);
        }

    }
}
