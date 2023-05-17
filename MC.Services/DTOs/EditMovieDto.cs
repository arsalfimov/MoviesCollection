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
        public string Director { get; set; } = null!;
        public double Rate { get; set; }
    }
}
