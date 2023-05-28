using MC.Domain;
using MC.PersistanceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MC.PersistanceServices
{
    public class MoviesActorsRepository : IRepository<MoviesActors, Guid>, IGetEnumerable<MoviesActors, Guid>
    {
        private readonly MovieDbContext _context;

        public MoviesActorsRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<List<MoviesActors>> GetAllAsync()
        {
            return await _context.MoviesActors.Include(md => md.Movie.Director).Include(md => md.Actor).ToListAsync();
        }

        public async Task<MoviesActors> GetByIdAsync(Guid id)
        {
            var movie = await _context.MoviesActors.Include(m => m.Movie).Include(m => m.Actor).SingleOrDefaultAsync(m => m.Id.Equals(id));
            return movie;
        }
        
        public async Task<MoviesActors> AddAsync(MoviesActors moviesActors)
        {
            _context.MoviesActors.Add(moviesActors);
            await _context.SaveChangesAsync();
            return moviesActors;
        }

        public async Task<MoviesActors> UpdateAsync(MoviesActors moviesActors)
        {
            throw new NotSupportedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            var deleteActorFromMovie = await GetByIdAsync(id);
            _context.MoviesActors.Remove(deleteActorFromMovie);
            await _context.SaveChangesAsync();
        }

        public async Task <IEnumerable<MoviesActors>> GetRangeById (Guid id)
        {
            var movie = await _context.MoviesActors.Include(m => m.Movie).Include(m => m.Actor).Where(m => m.MovieId.Equals(id)).ToListAsync();
            return movie;
        }
    }
}
