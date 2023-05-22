using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MC.Domain
{
    public class MoviesRates
    {
        public string UserId { get; set; }
        public IdentityUser User { get; set; } 

        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public int Rate { get; set; }
    }
}
