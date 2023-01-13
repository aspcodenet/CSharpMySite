using Microsoft.EntityFrameworkCore;

namespace CSharpMySite.Data;
public class DataInitializer
{
    private readonly ApplicationDbContext _context;

    public DataInitializer(ApplicationDbContext context)
    {
        _context = context;
    }

    public void SeedData()
    {
        _context.Database.Migrate();
        SeedGenres();
        SeedMovies();
    }

    private void SeedMovies()
    {
        AddMovieIfNotExists("Highlander", "Russel Mulcahy", 1986, "Action");
        AddMovieIfNotExists("Alien", "Ridley Scott", 1979, "Sci-fi");
        AddMovieIfNotExists("Star Wars: A New Hope", "George Lucas", 1977, "Sci-fi");
    }

    private void AddMovieIfNotExists(string title, string director, int year, string genreName)
    {
        if (_context.Movies.Any(e => e.Title == title)) return;
        var genre = _context.Genres.First(e => e.Name == genreName);
        _context.Movies.Add(new Movie
        {
            Title = title,
            Director = director,
            Year = year,
            Genre = genre
        });
        _context.SaveChanges();

    }

    private void SeedGenres()
    {
        addGenreIfNotExists("Action");
        addGenreIfNotExists("Sci-fi");
        addGenreIfNotExists("Comedy");
    }

    private void addGenreIfNotExists(string name)
    {
        if (_context.Genres.Any(e => e.Name == name)) return;
        _context.Genres.Add(new Genre
        {
            Name = name,
        });
        _context.SaveChanges();
    }
}