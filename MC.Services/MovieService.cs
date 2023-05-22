using MC.Domain;
using MC.PersistanceInterfaces;
using MC.Services.DTOs;
using MC.Services.Interfaces;


namespace MC.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie, Guid> _movieRepository;

        public MovieService(IRepository<Movie, Guid> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            var postMovie = new Movie
            {
                Id = Guid.NewGuid(),
                Title = movie.Title,
                Actors = movie.Actors,
                Description = movie.Description,
                Director = movie.Director,
                Year = DateTime.Now.Year,
                Genre = movie.Genre
            };

            return await _movieRepository.AddAsync(postMovie);
        }

        public async Task DeleteMovieAsync(Guid id)
        {
            await _movieRepository.DeleteAsync(id);
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(Guid id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<Movie> UpdateMovieAsync(Guid id, EditMovieDto movie)
        {
            var existingMovie = await GetMovieByIdAsync(id);

            if (existingMovie == null)
            {
                throw new Exception($"Movie with id {id} not found.");
            }

            existingMovie.Title = movie.Title;
            existingMovie.DirectorId = movie.DirectorId;

            try
            {
                return await _movieRepository.UpdateAsync(existingMovie);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating movie with id {id}.", ex);
            }
        }
    }
}
