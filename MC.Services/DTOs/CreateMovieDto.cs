using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Services.DTOs
{
    public class CreateMovieDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; } = null!;
        public string Cover { get; set; }
        public Guid DirectorId { get; set; }
        public Guid[] Actors { get; set; }
        public List<CreateMovieRateDto> Rates { get; set; } = new List<CreateMovieRateDto>();
    }
    public class CreateMovieRateDto
    {
        public string UserId { get; set; }
        public int Rate { get; set; }
    }
}
