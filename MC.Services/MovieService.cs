using AutoMapper;
using MC.Domain;
using MC.PersistanceInterfaces;
using MC.Services.DTOs;
using MC.Services.Interfaces;

namespace MC.Services
{
    public class MovieService : IMoviesService
    {
        private readonly IRepository<Movie, Guid> _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IRepository<Movie, Guid> repository, IMapper mapper)
        {
            _movieRepository = repository;
            _mapper = mapper;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(Guid id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<Movie> AddMovieAsync(CreateMovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            await _movieRepository.AddAsync(movie);
            movie = await GetMovieByIdAsync(movie.Id);
            return movie;
        }

        public async Task<Movie> UpdateMovieAsync(Guid id, EditMovieDto movieDto)
        {
            var movie = await GetMovieByIdAsync(id);

            movie.Title = movieDto.Title;
            movie.Description = movieDto.Description;
            movie.DirectorId = movieDto.DirectorId;

            await _movieRepository.UpdateAsync(movie);
            return movie;
        }

        public async Task DeleteMovieAsync(Guid id)
        {
            await _movieRepository.DeleteAsync(id);
        } 
    }
}
