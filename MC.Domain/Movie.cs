using System.Text.Json.Serialization;

namespace MC.Domain
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; } = null!;
        public string Cover { get; set; }

        public Guid DirectorId { get; set; }
        public Director Director { get; set; }

        public List<MoviesActors> Actors { get; set; } = new List<MoviesActors>();
        public IEnumerable<MoviesRates> Rates { get; set;} = new List<MoviesRates>();

    }
}
