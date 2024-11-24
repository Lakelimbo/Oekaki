using Microsoft.EntityFrameworkCore;
using Oekaki.Data.Models;

namespace Oekaki.Data;

public static class ContextExtensions
{
    /// <summary>
    /// Will ensure that the URISlug parameter (on Users) is
    /// unique, regardless of Nickname.
    /// (e.g. two people with Nickname "James Bond", the first
    /// would be "james-bond", the second would be "james-bond-1")
    /// </summary>
    /// <param name="context">The database context</param>
    public static void EnsureUniqueURISlugs(this DbContext context)
    {
        IEnumerable<User> users = context
            .ChangeTracker.Entries<User>()
            .Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified)
            .Select(entry => entry.Entity);

        foreach (User user in users)
        {
            string originalSlug = user.URISlug;
            string slug = originalSlug;
            int counter = 1;

            while (context.Set<User>().Any(u => u.URISlug == slug && u.Id != user.Id))
            {
                slug = $"{originalSlug}";
                counter++;
            }

            user.URISlug = slug;
        }
    }
}
