using MC.Domain;
using MC.PersistanceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MC.PersistanceServices
{
    public class MovieRepository : IRepository<Movie, Guid>
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies.Include(m => m.Director).ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(Guid id)
        {
            var movie = await _context.Movies.Include(m => m.Director).SingleOrDefaultAsync(m => m.Id.Equals(id));
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
    }
}
