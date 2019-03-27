using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTOnlineServices.Models
{
    public class GCTContext : IdentityDbContext<ApplicationUser>
    {
        public GCTContext(DbContextOptions<GCTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<BasketTicket> BasketTickets { get; set; }
        public virtual DbSet<BookedSeat> BookedSeats { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Play> Plays { get; set; }
        public virtual DbSet<Performance> Performances { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<SoldTicket> SoldTickets { get; set; }
    }
}
