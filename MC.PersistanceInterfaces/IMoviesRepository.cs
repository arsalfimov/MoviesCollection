using MC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.PersistanceInterfaces
{
    public interface IMoviesRepository : IRepository<Movie, Guid>
    {
        Task RemoveMovieActorAsync(Guid movieId, Guid actorId);
        Task RemoveMovieActorsAsync(Guid movieId, List<Guid> actorIds);
        Task<List<Movie>> GetAllAsync(MovieOrderBy orderBy);

    }
}
