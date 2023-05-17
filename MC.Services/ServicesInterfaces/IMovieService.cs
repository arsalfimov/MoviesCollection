using MC.Domain;
using MC.Services.DTOs;

namespace MC.Services.ServicesInterfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(Guid id);
        Task<Movie> AddMovieAsync(Movie movie);
        Task<Movie> UpdateMovieAsync(Guid id, EditMovieDto movie);
        Task DeleteMovieAsync(Guid id);
    }
}
