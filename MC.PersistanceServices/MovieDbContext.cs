using MC.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MC.PersistanceServices
{
    public class MovieDbContext : IdentityDbContext<IdentityUser>
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MoviesActors> MoviesActors { get; set; }
        public DbSet<MoviesRates> MoviesRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MoviesActors>().HasKey(a => new { a.ActorId, a.MovieId });
            modelBuilder.Entity<MoviesActors>().HasKey(a => a.Id);
            modelBuilder.Entity<MoviesActors>().HasIndex(a => a.Id).IsUnique(true);
            modelBuilder.Entity<MoviesRates>().HasKey(a => new { a.MovieId, a.UserId });
        }

        //public static void Initialize(MovieDbContext context)
        //{
        //    //context.Database.EnsureDeleted();
        //    context.Database.EnsureCreated();
        //    //context.Database.Migrate();

        //    if (context.Movies.Any())
        //    {
        //        return;
        //    }

        //    //var movies = new Movie[]
        //    //{
        //    //    new Movie{Id = Guid.NewGuid(), Title="The Shawshank Redemption", Director="Frank Darabont", Year=1994, Genre="Drama", Rate=9.3},
        //    //    new Movie{Id = Guid.NewGuid(), Title="The Godfather", Director="Francis Ford Coppola", Year=1972, Genre="Crime, Drama", Rate=9.2},
        //    //    new Movie{Id = Guid.NewGuid(), Title="The Dark Knight", Director="Christopher Nolan", Year=2008, Genre="Action, Crime, Drama", Rate=9.0},
        //    //    new Movie{Id = Guid.NewGuid(), Title="The Lord of the Rings: The Return of the King", Director="Peter Jackson", Year=2003, Genre="Adventure, Drama, Fantasy", Rate=8.9},
        //    //    new Movie{Id = Guid.NewGuid(), Title="Forrest Gump", Director="Robert Zemeckis", Year=1994, Genre="Drama, Romance", Rate=8.8},
        //    //    new Movie{Id = Guid.NewGuid(), Title="Inception", Director="Christopher Nolan", Year=2010, Genre="Action, Adventure, Sci-Fi", Rate=8.8},
        //    //    new Movie{Id = Guid.NewGuid(), Title="The Matrix", Director="Lana Wachowski, Lilly Wachowski", Year=1999, Genre="Action, Sci-Fi", Rate=8.7}
        //    //};

        //    context.Movies.AddRange(movies);
        //    context.SaveChanges();
        //}
    }
}




