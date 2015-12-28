
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace McMovies.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            if (context.Database == null)
            {
                throw new Exception("DB is null");
            }

            if (context.McMovie.Any())
            {
                return;   // DB has been seeded
            }

            context.McMovie.AddRange(
                new McMovie
                {
                    Cast = "Jim Carrey, Jeff Daniels",
                    ReleaseDate = DateTime.Parse("2014-11-14"),
                    Review = "Better than expected",
                    RunTime = "1 hr. 49 min",
                    Title = "Dumb & Dumber To"
                }

            );
            context.SaveChanges();
        }
    }
}