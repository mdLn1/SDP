using GCTOnlineServices.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Models.ViewModels
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GCTContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GCTContext>>()))
            {


                // Look for any movies.

                if (context.Seats.Any())
                {
                    return;   // db has been seeded
                }




                //foreach(var performance in context.Performance)
                //{
                //    foreach(var seat in context.Seats)
                //    {
                //       context.BookedSeats.Add(new BookedSeats() { PerformanceId = performance.Id, Seatid = seat.Id, Booked = false});
                //    }

                ////}
                ///
                #region CreateSeats   

                // Band A
                context.Add(new Seat() { Band = "A", ColumnLetter = "A", RowNumber = 1, SeatNumber = 1 });
                context.Add(new Seat() { Band = "A", ColumnLetter = "B", RowNumber = 1, SeatNumber = 2 });
                context.Add(new Seat() { Band = "A", ColumnLetter = "C", RowNumber = 1, SeatNumber = 3 });
                context.Add(new Seat() { Band = "A", ColumnLetter = "D", RowNumber = 1, SeatNumber = 4 });
                context.Add(new Seat() { Band = "A", ColumnLetter = "E", RowNumber = 1, SeatNumber = 5 });
                context.Add(new Seat() { Band = "A", ColumnLetter = "F", RowNumber = 1, SeatNumber = 6 });
                context.Add(new Seat() { Band = "A", ColumnLetter = "A", RowNumber = 2, SeatNumber = 7 });
                context.Add(new Seat() { Band = "A", ColumnLetter = "B", RowNumber = 2, SeatNumber = 8 });
                context.Add(new Seat() { Band = "A", ColumnLetter = "C", RowNumber = 2, SeatNumber = 9 });
                context.Add(new Seat() { Band = "A", ColumnLetter = "D", RowNumber = 2, SeatNumber = 10 });
                context.Add(new Seat() { Band = "A", ColumnLetter = "E", RowNumber = 2, SeatNumber = 11 });
                context.Add(new Seat() { Band = "A", ColumnLetter = "F", RowNumber = 2, SeatNumber = 12 });

                // Band B
                context.Add(new Seat() { Band = "B", ColumnLetter = "A", RowNumber = 3, SeatNumber = 13 });
                context.Add(new Seat() { Band = "B", ColumnLetter = "B", RowNumber = 3, SeatNumber = 14 });
                context.Add(new Seat() { Band = "B", ColumnLetter = "C", RowNumber = 3, SeatNumber = 15 });
                context.Add(new Seat() { Band = "B", ColumnLetter = "D", RowNumber = 3, SeatNumber = 16 });
                context.Add(new Seat() { Band = "B", ColumnLetter = "B", RowNumber = 4, SeatNumber = 17 });
                context.Add(new Seat() { Band = "B", ColumnLetter = "C", RowNumber = 4, SeatNumber = 18 });

                // Band C
                context.Add(new Seat() { Band = "C", ColumnLetter = "A", RowNumber = 4, SeatNumber = 19 });
                context.Add(new Seat() { Band = "C", ColumnLetter = "D", RowNumber = 4, SeatNumber = 20 });
                context.Add(new Seat() { Band = "C", ColumnLetter = "A", RowNumber = 5, SeatNumber = 21 });
                context.Add(new Seat() { Band = "C", ColumnLetter = "B", RowNumber = 5, SeatNumber = 22 });
                context.Add(new Seat() { Band = "C", ColumnLetter = "C", RowNumber = 5, SeatNumber = 23 });
                context.Add(new Seat() { Band = "C", ColumnLetter = "D", RowNumber = 5, SeatNumber = 24 });
                context.Add(new Seat() { Band = "C", ColumnLetter = "E", RowNumber = 5, SeatNumber = 25 });
                context.Add(new Seat() { Band = "C", ColumnLetter = "F", RowNumber = 5, SeatNumber = 26 });
                context.Add(new Seat() { Band = "C", ColumnLetter = "G", RowNumber = 5, SeatNumber = 27 });
                context.Add(new Seat() { Band = "C", ColumnLetter = "H", RowNumber = 5, SeatNumber = 28 });

                //int count = 0;
                //int actPlace = 1;
                //for (int i = 1; i < 13; i++)
                //{
                //    count++;
                //    if (i == 7)
                //    {
                //        actPlace = 1;
                //    }
                //    context.Add(new Seat() { RowNumber = "A", ColumnNumber = i.ToString() });
                //    actPlace++;

                //}
                //for (int i = 13; i < 19; i++)
                //{
                //    count++;
                //    context.Add(new Seat() { RowNumber = "B", ColumnNumber = i.ToString() });

                //}

                //for (int i = 19; i < 29; i++)
                //{
                //    count++;
                //    context.Add(new Seats() { RowNumber = "C", ColumnNumber = i.ToString() });

                //}
                #endregion

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
