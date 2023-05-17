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

        public async Task<Movie> AddAsync(Movie movie)
        {
            _context.Movies.AddRange(movie);

            if (await _context.SaveChangesAsync() >= 1)
            {
                return movie;
            }
            else
            {
                throw new Exception("error");
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var movieToDelete = await GetByIdAsync(id);

            if (movieToDelete == null)
            {
                throw new ArgumentException($"Movie with id {id} does not exist.");
            }

            _context.Movies.Remove(movieToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(Guid id)
        {
            var movie = await _context.Movies.SingleOrDefaultAsync(m => m.Id.Equals(id));
            return movie;
        }


        public async Task<Movie> UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);

            if (await _context.SaveChangesAsync() >= 1)
            {
                return movie;
            }
            else
            {
                throw new Exception("Error updating movie.");
            }
        }
    }
}
