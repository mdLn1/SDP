﻿// <auto-generated />
using System;
using GCTProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GCTProject.Migrations
{
    [DbContext(typeof(GCTProjectContext))]
    partial class GCTProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GCTProject.Data.Account", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("CustomerId")
                        .HasMaxLength(450);

                    b.Property<int?>("Cvc")
                        .HasColumnName("CVC");

                    b.Property<string>("ExpiryDate")
                        .HasMaxLength(10);

                    b.Property<string>("Last4")
                        .HasMaxLength(10);

                    b.HasKey("UserId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("GCTProject.Data.AgencyOrClub", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.HasKey("UserId");

                    b.ToTable("AgencyOrClub");
                });

            modelBuilder.Entity("GCTProject.Data.AspNetRoleClaims", b =>
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

            modelBuilder.Entity("GCTProject.Data.AspNetRoles", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("GCTProject.Data.AspNetUserClaims", b =>
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

            modelBuilder.Entity("GCTProject.Data.AspNetUserLogins", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("GCTProject.Data.AspNetUserRoles", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("GCTProject.Data.AspNetUserTokens", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GCTProject.Data.AspNetUsers", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

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
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("GCTProject.Data.Basket", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("ShippingMethod")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("GCTProject.Data.BasketTickets", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("PerformanceId");

                    b.Property<int>("SeatId");

                    b.Property<string>("ShippingMethod")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("UserId", "PerformanceId", "SeatId");

                    b.HasIndex("PerformanceId");

                    b.HasIndex("SeatId");

                    b.ToTable("BasketTickets");
                });

            modelBuilder.Entity("GCTProject.Data.BookedSeats", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("Seatid");

                    b.Property<string>("PerformanceId");

                    b.Property<byte>("Booked");

                    b.HasKey("Id", "Seatid", "PerformanceId");

                    b.HasIndex("PerformanceId");

                    b.HasIndex("Seatid");

                    b.ToTable("BookedSeats");
                });

            modelBuilder.Entity("GCTProject.Data.Customer", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.HasKey("UserId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("GCTProject.Data.Order", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("DeliveryMethod")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("smalldatetime");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("GCTProject.Data.Performance", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("AgeRestriction")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<byte[]>("Picture");

                    b.Property<string>("PriceBand")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Performance");
                });

            modelBuilder.Entity("GCTProject.Data.PerformanceDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PerformanceId");

                    b.Property<DateTime>("Date")
                        .HasColumnType("smalldatetime");

                    b.HasKey("Id", "PerformanceId");

                    b.HasIndex("PerformanceId");

                    b.ToTable("PerformanceDate");
                });

            modelBuilder.Entity("GCTProject.Data.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PerformanceId");

                    b.Property<string>("UserId");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<byte[]>("Date")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.HasKey("Id", "PerformanceId", "UserId");

                    b.HasIndex("PerformanceId");

                    b.HasIndex("UserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("GCTProject.Data.Seats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColumnNumber")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("RowName")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("GCTProject.Data.StaffMembers", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("Number");

                    b.HasKey("UserId");

                    b.ToTable("StaffMembers");
                });

            modelBuilder.Entity("GCTProject.Data.Tickets", b =>
                {
                    b.Property<string>("PerformanceId");

                    b.Property<int>("SeatId");

                    b.HasKey("PerformanceId", "SeatId");

                    b.HasIndex("SeatId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("GCTProject.Data.Account", b =>
                {
                    b.HasOne("GCTProject.Data.AspNetUsers", "User")
                        .WithOne("Account")
                        .HasForeignKey("GCTProject.Data.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GCTProject.Data.AgencyOrClub", b =>
                {
                    b.HasOne("GCTProject.Data.AspNetUsers", "User")
                        .WithOne("AgencyOrClub")
                        .HasForeignKey("GCTProject.Data.AgencyOrClub", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GCTProject.Data.AspNetRoleClaims", b =>
                {
                    b.HasOne("GCTProject.Data.AspNetRoles", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GCTProject.Data.AspNetUserClaims", b =>
                {
                    b.HasOne("GCTProject.Data.AspNetUsers", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GCTProject.Data.AspNetUserLogins", b =>
                {
                    b.HasOne("GCTProject.Data.AspNetUsers", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GCTProject.Data.AspNetUserRoles", b =>
                {
                    b.HasOne("GCTProject.Data.AspNetRoles", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GCTProject.Data.AspNetUsers", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GCTProject.Data.AspNetUserTokens", b =>
                {
                    b.HasOne("GCTProject.Data.AspNetUsers", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GCTProject.Data.Basket", b =>
                {
                    b.HasOne("GCTProject.Data.AspNetUsers", "User")
                        .WithOne("Basket")
                        .HasForeignKey("GCTProject.Data.Basket", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GCTProject.Data.BasketTickets", b =>
                {
                    b.HasOne("GCTProject.Data.Performance", "Performance")
                        .WithMany("BasketTickets")
                        .HasForeignKey("PerformanceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GCTProject.Data.Seats", "Seat")
                        .WithMany("BasketTickets")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GCTProject.Data.AspNetUsers", "User")
                        .WithMany("BasketTickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GCTProject.Data.BookedSeats", b =>
                {
                    b.HasOne("GCTProject.Data.Performance", "Performance")
                        .WithMany("BookedSeats")
                        .HasForeignKey("PerformanceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GCTProject.Data.Seats", "Seat")
                        .WithMany("BookedSeats")
                        .HasForeignKey("Seatid")
                        .HasConstraintName("FK_BookedSeats_Seats_SeatId");
                });

            modelBuilder.Entity("GCTProject.Data.Customer", b =>
                {
                    b.HasOne("GCTProject.Data.AspNetUsers", "User")
                        .WithOne("Customer")
                        .HasForeignKey("GCTProject.Data.Customer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GCTProject.Data.PerformanceDate", b =>
                {
                    b.HasOne("GCTProject.Data.Performance", "Performance")
                        .WithMany("PerformanceDate")
                        .HasForeignKey("PerformanceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GCTProject.Data.Review", b =>
                {
                    b.HasOne("GCTProject.Data.Performance", "Performance")
                        .WithMany("Review")
                        .HasForeignKey("PerformanceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GCTProject.Data.AspNetUsers", "User")
                        .WithMany("Review")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GCTProject.Data.StaffMembers", b =>
                {
                    b.HasOne("GCTProject.Data.AspNetUsers", "User")
                        .WithOne("StaffMembers")
                        .HasForeignKey("GCTProject.Data.StaffMembers", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GCTProject.Data.Tickets", b =>
                {
                    b.HasOne("GCTProject.Data.Performance", "Performance")
                        .WithMany("Tickets")
                        .HasForeignKey("PerformanceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GCTProject.Data.Seats", "Seat")
                        .WithMany("Tickets")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
