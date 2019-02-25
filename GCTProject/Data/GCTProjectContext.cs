using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GCTProject.Data
{
    public partial class GCTProjectContext : DbContext
    {
        public GCTProjectContext()
        {
        }

        public GCTProjectContext(DbContextOptions<GCTProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AgencyOrClub> AgencyOrClub { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<BasketTickets> BasketTickets { get; set; }
        public virtual DbSet<BookedSeats> BookedSeats { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Performance> Performance { get; set; }
        public virtual DbSet<PerformanceDate> PerformanceDate { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Seats> Seats { get; set; }
        public virtual DbSet<StaffMembers> StaffMembers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=V-NITRO15\\SQLEXPRESS;Database=GCTProjectContext;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasMaxLength(450);

                entity.Property(e => e.Cvc).HasColumnName("CVC");

                entity.Property(e => e.ExpiryDate).HasMaxLength(10);

                entity.Property(e => e.Last4).HasMaxLength(10);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Account)
                    .HasForeignKey<Account>(d => d.UserId);
            });

            modelBuilder.Entity<AgencyOrClub>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.AgencyOrClub)
                    .HasForeignKey<AgencyOrClub>(d => d.UserId);
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Basket>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.ShippingMethod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Basket)
                    .HasForeignKey<Basket>(d => d.UserId);
            });

            modelBuilder.Entity<BasketTickets>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BookedSeatId });

                entity.HasOne(d => d.BookedSeat)
                    .WithMany(p => p.BasketTickets)
                    .HasForeignKey(d => d.BookedSeatId)
                    .HasConstraintName("FK_BasketTickets_BookedSeats_BookedSeatsId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BasketTickets)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_BasketTickets_AspNetUsers_AspNetUsersId");
            });

            modelBuilder.Entity<BookedSeats>(entity =>
            {
                entity.Property(e => e.ExpiryTime).HasColumnType("smalldatetime");

                entity.HasOne(d => d.PerformanceDate)
                    .WithMany(p => p.BookedSeats)
                    .HasForeignKey(d => d.PerformanceDateId);

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.BookedSeats)
                    .HasForeignKey(d => d.Seatid)
                    .HasConstraintName("FK_BookedSeats_Seats_SeatId");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Customer)
                    .HasForeignKey<Customer>(d => d.UserId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeliveryMethod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OrderTime).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<Performance>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AgeRestriction)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.PriceBand)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PerformanceDate>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.PerformanceId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Performance)
                    .WithMany(p => p.PerformanceDate)
                    .HasForeignKey(d => d.PerformanceId);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PerformanceId, e.UserId });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Date)
                    .IsRequired()
                    .IsRowVersion();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Performance)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.PerformanceId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Seats>(entity =>
            {
                entity.Property(e => e.ColumnNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.RowName)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<StaffMembers>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.StaffMembers)
                    .HasForeignKey<StaffMembers>(d => d.UserId);
            });
        }
    }
}
