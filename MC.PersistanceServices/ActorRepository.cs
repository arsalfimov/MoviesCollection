using MC.Domain;
using MC.PersistanceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MC.PersistanceServices
{
    public class ActorRepository : IActorsRepository
    {
        private readonly MovieDbContext _context;

        public ActorRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<List<Actor>> GetAllAsync()
        {
            return await _context.Actors.ToListAsync();
        }

        public async Task<Actor> GetByIdAsync(Guid id)
        {
            var actor = await _context.Actors.SingleOrDefaultAsync(a => a.Id.Equals(id));
            return actor;
        }

        public async Task<Actor> AddAsync(Actor actor)
        {
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();
            return actor;
        }

        public async Task<Actor> UpdateAsync(Actor actor)
        {
            _context.Actors.Update(actor);
            await _context.SaveChangesAsync();
            return actor;
        }

        public async Task DeleteAsync(Guid id)
        {
            var actor = await GetByIdAsync(id);
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetActorsByIds(Guid[] ids)
        {
            return await _context.Actors.Where(a => ids.Contains(a.Id)).ToListAsync();
        }
    }
}