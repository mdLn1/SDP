using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTProject.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GCTProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GCTProjectContext>>()))
            {
                // Look for any movies.
                if (context.Seats.Any())
                {
                    return;   // DB has been seeded
                }
                //foreach(var performance in context.Performance)
                //{
                //    foreach(var seat in context.Seats)
                //    {
                //       context.BookedSeats.Add(new BookedSeats() { PerformanceId = performance.Id, Seatid = seat.Id, Booked = false});
                //    }

                ////}
                int count = 0;
                int actPlace = 1;
                for (int i = 1; i < 13; i++)
                {
                    count++;
                    if (i == 7)
                    {
                        actPlace = 1;
                    }
                    context.Add(new Seats() { RowName = "A", ColumnNumber = i.ToString() });
                    actPlace++;

                }
                for (int i = 13; i < 19; i++)
                {
                    count++;
                    context.Add(new Seats() { RowName = "B", ColumnNumber = i.ToString() });

                }

                for (int i = 19; i < 29; i++)
                {
                    count++;
                    context.Add(new Seats() { RowName = "C", ColumnNumber = i.ToString() });

                }

                //context.Movie.AddRange(
                //    new Movie
                //    {
                //        Title = "When Harry Met Sally",
                //        ReleaseDate = DateTime.Parse("1989-2-12"),
                //        Genre = "Romantic Comedy",
                //        Rating = "R",
                //        Price = 7.99M
                //    },

                //    new Movie
                //    {
                //        Title = "Ghostbusters ",
                //        ReleaseDate = DateTime.Parse("1984-3-13"),
                //        Genre = "Comedy",
                //        Rating = "R",
                //        Price = 8.99M
                //    },

                //    new Movie
                //    {
                //        Title = "Ghostbusters 2",
                //        ReleaseDate = DateTime.Parse("1986-2-23"),
                //        Genre = "Comedy",
                //        Rating = "R",
                //        Price = 9.99M
                //    },

                //    new Movie
                //    {
                //        Title = "Rio Bravo",
                //        ReleaseDate = DateTime.Parse("1959-4-15"),
                //        Genre = "Western",
                //        Rating = "R",
                //        Price = 3.99M
                //    }
                //);
                context.SaveChanges();
            }
        }
    }
}
