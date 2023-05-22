using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Services.DTOs
{
    public class EditMovieDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid DirectorId { get; set; }
    }
}
