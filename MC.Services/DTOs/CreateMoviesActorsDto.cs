using MC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Services.DTOs
{
    public class CreateMoviesActorsDto
    {
        public Guid MovieId { get; set; }
        public Guid ActorId { get; set; }
    }
}
