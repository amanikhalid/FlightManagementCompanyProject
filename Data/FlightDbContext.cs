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

        }

    }
}
