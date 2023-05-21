namespace MC.Domain
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Director { get; set; } = null!;
        public int Year { get; set; }
        public string Genre { get; set; } = null!;
        public double Rate { get; set; }
    }
}
