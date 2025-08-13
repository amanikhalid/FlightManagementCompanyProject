using FlightManagementCompanyProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Data
{
    public class FlightDbContext : DbContext // DbContext for the Flight Management Company Project
    {
        public DbSet<Aircraft> Aircrafts { get; set; } // DbSet for Aircraft entities
        public DbSet<AircraftMaintenance> AircraftMaintenances { get; set; } // DbSet for AircraftMaintenance entities

        public DbSet<Airport> Airports { get; set; } // DbSet for Airport entities

        public DbSet<Baggage> Baggages { get; set; } // DbSet for Baggage entities

        public DbSet<Booking> Bookings { get; set; } // DbSet for Booking entities

        public DbSet<CrewMember> CrewMembers { get; set; } // DbSet for CrewMember entities

        public DbSet<Flight> Flights { get; set; } // DbSet for Flight entities

        public DbSet<FlightCrew> FlightCrews { get; set; } // DbSet for FlightCrew entities

        public DbSet<Passenger> Passengers { get; set; } // DbSet for Passenger entities

        public DbSet<Route> Routes { get; set; } // DbSet for Route entities

        public DbSet<Ticket> Tickets { get; set; } // DbSet for Ticket entities

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the database connection string 
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-73KN3D2;Initial Catalog=FlightManagementSystemDB;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Airport Entity Configuration
            modelBuilder.Entity<Airport>()
                .HasKey(a => a.AirportId); // Set AirportId as the primary key

            // Airport auto-increment configuration
            modelBuilder.Entity<Airport>()
                .Property(a => a.AirportId)
                .ValueGeneratedOnAdd()// Configure AirportId to be auto-incremented
                .HasColumnType("int"); // Specify the column type as int

            // IATA code configuration
            modelBuilder.Entity<Airport>()
                .Property(a => a.IATA)
                .IsRequired() // IATA code is required
                .HasMaxLength(3) // IATA code has a maximum length of 3 characters
                .HasColumnType("nvarchar(3)"); // Specify the column type as nvarchar(3)

            // Unique constraint for IATA code
            modelBuilder.Entity<Airport>()
                .HasIndex(a => a.IATA)
                .IsUnique(); // Ensure that IATA code is unique across all airports

            // Name configuration
            modelBuilder.Entity<Airport>()
                .Property(a => a.Name)
                .IsRequired() // Name is required
                .HasMaxLength(100) // Maximum length of 100 characters
                .HasColumnType("nvarchar(100)"); // Specify the column type as nvarchar(100)

            // City configuration
            modelBuilder.Entity<Airport>()
                .Property(a => a.City)
                .IsRequired() // City is required
                .HasMaxLength(50) // Maximum length of 50 characters
                .HasColumnType("nvarchar(50)"); // Specify the column type as nvarchar(50)

            // Country configuration
            modelBuilder.Entity<Airport>()
                .Property(a => a.Country)
                .IsRequired() // Country is required
                .HasMaxLength(50) // Maximum length of 50 characters
                .HasColumnType("nvarchar(50)"); // Specify the column type as nvarchar(50)

            // TimeZone configuration
            modelBuilder.Entity<Airport>()
                .Property(a => a.TimeZone)
                .IsRequired() // TimeZone is required
                .HasMaxLength(50) // Maximum length of 50 characters
                .HasColumnType("nvarchar(50)"); // Specify the column type as nvarchar(50)

            // Navigation properties for Airport
            // one-to-many relationship with Route
            modelBuilder.Entity<Airport>()
                .HasMany(a => a.OriginRoutes) // An airport can have many origin routes
                .WithOne(r => r.OriginAirport) // Each route has one origin airport
                .HasForeignKey(r => r.OriginAirportId) // Foreign key in Route table
            .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for origin routes
            modelBuilder.Entity<Airport>() 
                .HasMany(a => a.DestinationRoutes) // An airport can have many destination routes
                .WithOne(r => r.DestinationAirport) // Each route has one destination airport
                .HasForeignKey(r => r.DestinationAirportId) // Foreign key in Route table
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for destination routes

            // Route Entity Configuration
            modelBuilder.Entity<Route>()
                .HasKey(r => r.RouteId); // Set RouteId as the primary key
            // Route auto-increment configuration
            modelBuilder.Entity<Route>()
                .Property(r => r.RouteId)
                .ValueGeneratedOnAdd() // Configure RouteId to be auto-incremented
                .HasColumnType("int"); // Specify the column type as int

            // DistanceKm configuration
            modelBuilder.Entity<Route>()
                .Property(r => r.DistanceKm)
                .IsRequired() // DistanceKm is required
                .HasColumnType("int"); // Specify the column type as int

            // Navigation properties for Route
            // one-to-many relationship with Flight
            modelBuilder.Entity<Route>()
                .HasMany(r => r.Flights) // A route can have many flights
                .WithOne(f => f.Route) // Each flight has one route
                .HasForeignKey(f => f.RouteId) // Foreign key in Flight table
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for flights

            // one-to-many relationship with Airport
            modelBuilder.Entity<Route>()
                .HasOne(r => r.OriginAirport) // Each route has one origin airport
                .WithMany(a => a.OriginRoutes) // An airport can have many origin routes
                .HasForeignKey(r => r.OriginAirportId) // Foreign key in Route table
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for origin airport

            modelBuilder.Entity<Route>()
                .HasOne(r => r.DestinationAirport) // Each route has one destination airport
                .WithMany(a => a.DestinationRoutes) // An airport can have many destination routes
                .HasForeignKey(r => r.DestinationAirportId) // Foreign key in Route table
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for destination airport

            // Flight Entity Configuration
            modelBuilder.Entity<Flight>()
                .HasKey(f => f.FlightId); // Set FlightId as the primary key

            // Flight auto-increment configuration
            modelBuilder.Entity<Flight>()
                .Property(f => f.FlightId)
                .ValueGeneratedOnAdd() // Configure FlightId to be auto-incremented
                .HasColumnType("int"); // Specify the column type as int

            // FlightNumber configuration
            modelBuilder.Entity<Flight>() 





        }

    }
}
