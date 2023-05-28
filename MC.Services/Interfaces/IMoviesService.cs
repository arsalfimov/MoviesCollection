using MC.Domain;
using MC.Services.DTOs;

namespace MC.Services.Interfaces
{
    public interface IMoviesService
    {
        Task<List<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(Guid id);
        Task<Movie> AddMovieAsync(CreateMovieDto movieDto);
        Task<Movie> UpdateMovieAsync(Guid id, EditMovieDto movieDto);
        Task DeleteMovieAsync(Guid id);
    }
}
