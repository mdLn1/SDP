﻿// <auto-generated />
using System;
using GCTOnlineServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GCTOnlineServices.Migrations
{
    [DbContext(typeof(GCTContext))]
    partial class GCTContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GCTOnlineServices.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("AgencyOrClubName");

                    b.Property<bool?>("ApprovedMultipleDiscounts");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("IdNumber");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SavedCustomerCard");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("GCTOnlineServices.Models.Basket", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("ShippingMethod");

                    b.Property<decimal>("TotalPrice");

                    b.HasKey("UserId");

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("GCTOnlineServices.Models.BasketTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BasketId");

                    b.Property<int>("BookedSeatId");

                    b.Property<int>("PerformanceId");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("BookedSeatId");

                    b.HasIndex("PerformanceId");

                    b.ToTable("BasketTickets");
                });

            modelBuilder.Entity("GCTOnlineServices.Models.BookedSeat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Booked");

                    b.Property<DateTime?>("ExpiryTime");

                    b.Property<int>("PerformanceId");

                    b.Property<int>("SeatId");

                    b.HasKey("Id");

                    b.HasIndex("PerformanceId");

                    b.HasIndex("SeatId");

                    b.ToTable("BookedSeats");
                });

            modelBuilder.Entity("GCTOnlineServices.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientName");

                    b.Property<string>("DeliveryMethod");

                    b.Property<bool>("IsPrinted");

                    b.Property<DateTime>("OrderTime");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GCTOnlineServices.Models.Performance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("PlayId");

                    b.HasKey("Id");

                    b.HasIndex("PlayId");

                    b.ToTable("Performances");
                });

            modelBuilder.Entity("GCTOnlineServices.Models.Play", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AgeRestriction");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<byte[]>("Picture");

                    b.Property<decimal>("PriceEnd");

                    b.Property<decimal>("PriceStart");

                    b.HasKey("Id");

                    b.ToTable("Plays");
                });

            modelBuilder.Entity("GCTOnlineServices.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasMaxLength(400);

                    b.Property<DateTime>("Date");

                    b.Property<int>("PlayId");

                    b.Property<string>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("PlayId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("GCTOnlineServices.Models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Band");

                    b.Property<string>("ColumnLetter");

                    b.Property<int>("RowNumber");

                    b.Property<int>("SeatNumber");

                    b.HasKey("Id");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("GCTOnlineServices.Models.SoldTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Band");

                    b.Property<string>("ColumnLetter");

                    b.Property<string>("CustomerName");

                    b.Property<int>("OrderId");

                    b.Property<decimal>("PaidPrice");

                    b.Property<DateTime>("PerformanceTimeAndDate");

                    b.Property<string>("PlayName");

                    b.Property<int>("RowNumber");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("SoldTickets");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GCTOnlineServices.Models.Basket", b =>
                {
                    b.HasOne("GCTOnlineServices.Models.ApplicationUser", "User")
                        .WithOne("Basket")
                        .HasForeignKey("GCTOnlineServices.Models.Basket", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GCTOnlineServices.Models.BasketTicket", b =>
                {
                    b.HasOne("GCTOnlineServices.Models.Basket", "Basket")
                        .WithMany("Tickets")
                        .HasForeignKey("BasketId");

                    b.HasOne("GCTOnlineServices.Models.BookedSeat", "BookedSeat")
                        .WithMany("BasketTickets")
                        .HasForeignKey("BookedSeatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GCTOnlineServices.Models.Performance", "Performance")
                        .WithMany()
                        .HasForeignKey("PerformanceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GCTOnlineServices.Models.BookedSeat", b =>
                {
                    b.HasOne("GCTOnlineServices.Models.Performance", "Performance")
                        .WithMany("BookedSeats")
                        .HasForeignKey("PerformanceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GCTOnlineServices.Models.Seat", "Seat")
                        .WithMany("BookedSeats")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GCTOnlineServices.Models.Order", b =>
                {
                    b.HasOne("GCTOnlineServices.Models.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GCTOnlineServices.Models.Performance", b =>
                {
                    b.HasOne("GCTOnlineServices.Models.Play", "Play")
                        .WithMany("Performances")
                        .HasForeignKey("PlayId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GCTOnlineServices.Models.Review", b =>
                {
                    b.HasOne("GCTOnlineServices.Models.Play", "Play")
                        .WithMany("Reviews")
                        .HasForeignKey("PlayId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GCTOnlineServices.Models.ApplicationUser", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GCTOnlineServices.Models.SoldTicket", b =>
                {
                    b.HasOne("GCTOnlineServices.Models.Order", "Order")
                        .WithMany("SoldTickets")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GCTOnlineServices.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GCTOnlineServices.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GCTOnlineServices.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GCTOnlineServices.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GCTOnlineServices.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
