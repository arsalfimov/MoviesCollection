using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Domain
{
    public class Actor
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patr { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int Year { get; set; }
    }
}
