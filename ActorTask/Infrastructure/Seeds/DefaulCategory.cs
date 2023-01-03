using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Seeds;

public static class DefaulCategory
{
    public static async Task SeedAsync(DataContext _context)
    {
        var roles = new List<string>()
        {
            "Actor",
            "Comedy",
            "Fantasy"
        };

        foreach(var role in roles)
        {
            var categoryExisting = _context.Categories.FirstOrDefault(c => c.Title == role);
            // await context.Categories.Add(existing);
            if( categoryExisting == null )
            {
                var newCategory = new Category()
                {
                    Title = role
                };
                _context.Categories.Add(newCategory);
            }
        }
        await _context.SaveChangesAsync();
    }
}
