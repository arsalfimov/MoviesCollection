using MC.Domain;
using MC.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Services.Interfaces
{
    public interface IMoviesActorsService
    {
        Task<List<MoviesActors>> GetAllMoviesActorsAsync();
        Task<MoviesActors> GetMoviesActorsByIdAsync(Guid id);
        Task<MoviesActors> AddMoviesActorsAsync(CreateMoviesActorsDto moviesActorsDto);
        //Task<MoviesActors> UpdateMoviesActorsAsync(Guid id, MoviesActors moviesActors);
        Task DeleteMoviesActorsAsync(Guid id);
        Task<IEnumerable<MoviesActors>> GetRangeById(Guid id);
    }
}
