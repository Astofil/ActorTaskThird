using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Seeds;

public static class DefaultMovie
{
    public static async Task SeedAsync(DataContext _context)
    {
        var roles = new List<string>()
        {
            "Infinity War",
            "Avengers: EndGame",
            "Endless Love",
            "Arusi Zamonavi",
        };

        foreach(var role in roles)
        {
            var movieExisting = _context.Movies.FirstOrDefault(m => m.Title == role);
            if( movieExisting == null)
            {
                var newMovie = new Movie()
                {
                    Title = role,
                    MovieYear = 2014
                };
                _context.Movies.Add(newMovie);
            }
        }
        await _context.SaveChangesAsync();
    }
}
