using MC.Domain;
using MC.PersistanceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MC.PersistanceServices
{
    public class DirectorRepository : IRepository<Director, Guid>
    {
        private readonly MovieDbContext _context;

        public DirectorRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<List<Director>> GetAllAsync()
        {
            return await _context.Directors.ToListAsync();
        }

        public async Task<Director> GetByIdAsync(Guid id)
        {
            var director = await _context.Directors.SingleOrDefaultAsync(d => d.Id == id);
            return director;
        }

        public async Task<Director> AddAsync(Director director)
        {
            _context.Directors.Add(director);
            await _context.SaveChangesAsync();
            return director;
        }

        public async Task<Director> UpdateAsync(Director director)
        {
            _context.Directors.Update(director);
            await _context.SaveChangesAsync();
            return director;
        }

        public async Task DeleteAsync(Guid id)
        {
            var director = await GetByIdAsync(id);
            _context.Directors.Remove(director);
            await _context.SaveChangesAsync();
        }   
    }
}