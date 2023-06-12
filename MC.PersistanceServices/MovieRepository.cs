using MC.Domain;
using MC.PersistanceInterfaces;
using MC.PersistanceServices.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace MC.PersistanceServices
{
    public class MovieRepository : IMoviesRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies.Include(m => m.Director)
                .Include(m => m.Actors)
                .ThenInclude(m => m.Actor)
                .ToListAsync();
        }

        public async Task<List<Movie>> GetAllAsync(MovieOrderBy orderBy)
        {
            var query = _context.Movies.AsQueryable();
            switch (orderBy)
            {
                case MovieOrderBy.Title:
                    query = query.OrderBy(x => x.Title);
                    break;
                case MovieOrderBy.Year:
                    query = query.OrderBy(x => x.Year);
                    break;
                default:
                    break;
            }
            
            return await query.Include(m => m.Director)
                .Include(m => m.Actors)
                .ThenInclude(m => m.Actor)
                .ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(Guid id)
        {
            var movie = await _context.Movies.Include(m => m.Director)
                                             .Include(m => m.Actors)
                                             .ThenInclude(m => m.Actor)
                                             .SingleOrDefaultAsync(m => m.Id.Equals(id));
            return movie;
        }

        public async Task<Movie> AddAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task DeleteAsync(Guid id)
        {
            var movieToDelete = await GetByIdAsync(id);
            _context.Movies.Remove(movieToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveMovieActorAsync(Guid movieId, Guid actorId)
        {
            var movie = await _context.Movies.Include(m => m.Actors).FirstOrDefaultAsync(m => m.Id == movieId);
            if (movie != null)
            {
                var movieActor = movie.Actors.FirstOrDefault(a => a.ActorId == actorId);
                if (movieActor != null)
                {
                    movie.Actors.Remove(movieActor);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task RemoveMovieActorsAsync(Guid movieId, List<Guid> actorIds)
        {
            var movie = await _context.Movies.Include(m => m.Actors).FirstOrDefaultAsync(m => m.Id == movieId);
            if (movie == null)
            {
                throw new Exception($"Movie with ID {movieId} not found."); 
            }

            foreach (var actorId in actorIds)
            {
                var movieActor = movie.Actors.FirstOrDefault(a => a.ActorId == actorId);
                if (movieActor != null)
                {
                    movie.Actors.Remove(movieActor);
                }
                else
                {
                    throw new Exception($"Actor with ID {actorId} not found.");
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}

