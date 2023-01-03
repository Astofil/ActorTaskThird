using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Seeds;

public static class DefaultActor
{
    public static async Task SeedAsync(DataContext _context)
    {
        var roles = new List<string>()
        {
            "Robert Downey Jr",
            "Brad Pitt",
            "Tom Holland",
        };

        foreach(var role in roles)
        {
            var actorExisting = _context.Actors.FirstOrDefault(a => a.FullName == role);
            if( actorExisting == null)
            {
                var newActor = new Actor()
                {
                    FullName = role,
                    Gender = "male",
                    BirthYear = 2004,
                    DeathYear = 2084,
                };
                _context.Actors.Add(newActor);
            }
        }
        await _context.SaveChangesAsync();
    }
}
