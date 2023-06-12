
using MC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.PersistanceInterfaces
{
    public interface IActorsRepository : IRepository<Actor, Guid>
    {
        Task<IEnumerable<Actor>> GetActorsByIds(Guid[] ids);
    }
}
