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
                .Property(f => f.FlightNumber) // Flight number is required
                .IsRequired() 
                .HasMaxLength(10) // Maximum length of 10 characters
                .HasColumnType("nvarchar(10)"); // Specify the column type as nvarchar(10)

            //unique constraint for FlightNumber
            modelBuilder.Entity<Flight>()
                .HasIndex(f => f.FlightNumber)
                .IsUnique(); // Ensure that FlightNumber is unique across all flights

            // DepartureUtc configuration
            modelBuilder.Entity<Flight>()
                .Property(f => f.DepartureUtc) // Departure time is required
                .IsRequired()
                .HasColumnType("datetime"); // Specify the column type as datetime

            // unique constraint for DepartureUtc
            modelBuilder.Entity<Flight>()
                .HasIndex(f => f.DepartureUtc)
                .IsUnique(); // Ensure that DepartureUtc is unique across all flights

            // ArrivalUtc configuration
            modelBuilder.Entity<Flight>()
                .Property(f => f.ArrivalUtc) // Arrival time is required
                .IsRequired()
                .HasColumnType("datetime"); // Specify the column type as datetime

            // Status configuration
            modelBuilder.Entity<Flight>()
                .Property(f => f.Status) // Status is required
                .IsRequired()
                .HasMaxLength(20) // Maximum length of 20 characters
                .HasColumnType("nvarchar(20)"); // Specify the column type as nvarchar(20)

            // Navigation properties for Flight
            // one-to-many relationship with Ticket
            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Tickets) // A flight can have many tickets
                .WithOne(t => t.Flight) // Each ticket has one flight
                .HasForeignKey(t => t.FlightId) // Foreign key in Ticket table
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for tickets

            // one-to-many relationship with FlightCrew
            modelBuilder.Entity<Flight>()
                .HasMany(f => f.FlightCrews) // A flight can have many flight crews
                .WithOne(fc => fc.Flight) // one flight 
                 .HasForeignKey(fc => fc.FlightId) // Foreign key in FlightCrew
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            // one-to-many relationship with Aircraft
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Aircraft) // one Aircraft
                  .WithMany(a => a.Flights) // many Flights in Aircraft
                  .HasForeignKey(f => f.AircraftId) // Foreign key in Flight
                   .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            // one-to-many relationship with Route
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Route) // one Route
                .WithMany(r => r.Flights) // many Flights in Route
                .HasForeignKey(f => f.RouteId) // Foreign key in Flight
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            // Ticket Entity Configuration
            modelBuilder.Entity<Ticket>()
                .HasKey(t => t.TicketId); // Set TicketId as the primary key

            // Ticket auto-increment configuration
            modelBuilder.Entity<Ticket>()
                .Property(t => t.TicketId)
                .ValueGeneratedOnAdd() // Configure TicketId to be auto-incremented
                .HasColumnType("int"); // Specify the column type as int

            // SeatNumber configuration
            modelBuilder.Entity<Ticket>()
                .Property(t => t.SeatNumber) // Seat number is required
                .IsRequired()
                .HasMaxLength(10) // Maximum length of 10 characters
                .HasColumnType("nvarchar(10)"); // Specify the column type as nvarchar(10)

            // Fare configuration
            modelBuilder.Entity<Ticket>()
                .Property(t => t.Fare) // Fare is required
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // Specify the column type as decimal with precision 18 and scale 2

            // CheckedIn configuration
            modelBuilder.Entity<Ticket>()
                .Property(t => t.CheckedIn) // CheckedIn is required
                .IsRequired()
                .HasColumnType("bit"); // Specify the column type as bit (boolean)

            // Navigation properties for Ticket
            // one-to-many relationship with Baggage
            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.Baggages) // A ticket can have many baggage items
                .WithOne(b => b.Ticket) // Each baggage item belongs to one ticket
                .HasForeignKey(b => b.TicketId) // Foreign key in Baggage table
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for baggage items

            // one-to-many relationship with Booking
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Booking) // Each ticket belongs to one booking
                .WithMany(b => b.Tickets) // A booking can have many tickets
                .HasForeignKey(t => t.BookingId) // Foreign key in Ticket table
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for bookings

            // one-to-many relationship with Flight
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Flight) // Each ticket belongs to one flight
                .WithMany(f => f.Tickets) // A flight can have many tickets
                .HasForeignKey(t => t.FlightId) // Foreign key in Ticket table
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for flights

            // Aircraft Entity Configuration
            modelBuilder.Entity<Aircraft>()
                .HasKey(a => a.AircraftId); // Set AircraftId as the primary key

            // Aircraft auto-increment configuration
            modelBuilder.Entity<Aircraft>()
                .Property(a => a.AircraftId)
                .ValueGeneratedOnAdd() // Configure AircraftId to be auto-incremented
                .HasColumnType("int"); // Specify the column type as int

            // TailNumber configuration
            modelBuilder.Entity<Aircraft>()
                .Property(a => a.TailNumber) // Tail number is required
                .IsRequired()
                .HasMaxLength(10) // Maximum length of 10 characters
                .HasColumnType("int"); // Specify the column type as int

            // Unique constraint for TailNumber
            modelBuilder.Entity<Aircraft>()
                .HasIndex(a => a.TailNumber)
                .IsUnique(); // Ensure that TailNumber is unique across all aircraft

            // Model configuration
            modelBuilder.Entity<Aircraft>()
                .Property(a => a.Model) // Model is required
                .IsRequired()
                .HasMaxLength(50) // Maximum length of 50 characters
                .HasColumnType("nvarchar(50)"); // Specify the column type as nvarchar(50)

            // Capacity configuration
            modelBuilder.Entity<Aircraft>()
                .Property(a => a.Capacity) // Capacity is required
                .IsRequired()
                .HasColumnType("int"); // Specify the column type as int

            // Navigation properties for Aircraft
            // one-to-many relationship with Flight
            modelBuilder.Entity<Aircraft>()
                .HasMany(a => a.Flights) // An aircraft can have many flights
                .WithOne(f => f.Aircraft) // Each flight has one aircraft
                .HasForeignKey(f => f.AircraftId) // Foreign key in Flight table
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for flights

            // one-to-many relationship with AircraftMaintenance
            modelBuilder.Entity<Aircraft>()
                .HasMany(a => a.AircraftMaintenances) // An aircraft can have many maintenance records
                .WithOne(am => am.Aircraft) // Each maintenance record belongs to one aircraft
                .HasForeignKey(am => am.AircraftId) // Foreign key in AircraftMaintenance table
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for maintenance records

            // AircraftMaintenance Entity Configuration
            modelBuilder.Entity<AircraftMaintenance>()
                .HasKey(am => am.MaintenanceId); // Set MaintenanceId as the primary key

            // AircraftMaintenance auto-increment configuration
            modelBuilder.Entity<AircraftMaintenance>()
                .Property(am => am.MaintenanceId)
                .ValueGeneratedOnAdd() // Configure MaintenanceId to be auto-incremented
                .HasColumnType("int"); // Specify the column type as int

            // MaintenanceDate configuration
            modelBuilder.Entity<AircraftMaintenance>()
                .Property(am => am.MaintenanceDate) // Maintenance date is required
                .IsRequired()
                .HasColumnType("datetime"); // Specify the column type as datetime

            // Type configuration
            modelBuilder.Entity<AircraftMaintenance>()
                .Property(am => am.Type) // Type of maintenance is required
                .IsRequired()
                .HasMaxLength(50) // Maximum length of 50 characters
                .HasColumnType("nvarchar(50)"); // Specify the column type as nvarchar(50)

            // Note configuration
            modelBuilder.Entity<AircraftMaintenance>()
                .Property(am => am.Notes) // Note is optional
                .IsRequired()
                .HasMaxLength(500) // Maximum length of 500 characters
                .HasColumnType("nvarchar(500)"); // Specify the column type as nvarchar(500)

            // Navigation properties for AircraftMaintenance
            // one-to-many relationship with Aircraft
            modelBuilder.Entity<AircraftMaintenance>()
                .HasOne(am => am.Aircraft) // Each maintenance record belongs to one aircraft
                .WithMany(a => a.AircraftMaintenances) // An aircraft can have many maintenance records
                .HasForeignKey(am => am.AircraftId) // Foreign key in AircraftMaintenance table
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for aircraft maintenance records

            // Passenger Entity Configuration
            modelBuilder.Entity<Passenger>()
                .HasKey(p => p.PassengerId); // Set PassengerId as the primary key

            // Passenger auto-increment configuration
            modelBuilder.Entity<Passenger>()
                .Property (p => p.PassengerId)
                .ValueGeneratedOnAdd() // Auto-increment primary key
                 .HasColumnType("int"); // int type for PassengerId

            // FullName configuration
            modelBuilder.Entity<Passenger>()
                .Property(p => p.FullName) 
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)"); // string type with max length 50

            // PassportNo configuration
            modelBuilder.Entity<Passenger>()
                .Property(p => p.PassportNo)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)"); // string type with max length 20

            // Unique constraint for PassportNo
            modelBuilder.Entity<Passenger>()
                .HasIndex(p => p.PassportNo)
                .IsUnique(); // Ensure that PassportNo is unique across all passengers

            // Nationality configuration
            modelBuilder.Entity<Passenger>()
                .Property(p => p.Nationality) 
                .IsRequired()
                .HasMaxLength(50) // Maximum length of 50 characters
                .HasColumnType("nvarchar(50)"); // Specify the column type as nvarchar(50)

            // DOB configuration
            modelBuilder.Entity<Passenger>()
                .Property(p => p.DOB) // Date of birth is required
                .IsRequired()
                .HasColumnType("datetime"); // Specify the column type as datetime

            // Navigation properties for Passenger
            // one-to-many relationship with Booking
            modelBuilder.Entity<Passenger>()
                .HasMany(p => p.Bookings) // A passenger can have many bookings
                .WithOne(b => b.Passenger) // Each booking belongs to one passenger
                .HasForeignKey(b => b.PassengerId) // Foreign key in Booking table
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for bookings

            // Booking Entity Configuration
            modelBuilder.Entity<Booking>()
                .HasKey(b => b.BookingId); // Set BookingId as the primary key

            // Booking auto-increment configuration
            modelBuilder.Entity<Booking>()
                .Property(b => b.BookingId)
                .ValueGeneratedOnAdd() // Configure BookingId to be auto-incremented
                .HasColumnType("int"); // Specify the column type as int

            // BookingRef configuration
            modelBuilder.Entity<Booking>()
                .Property(b => b.BookingRef) // Booking reference is required
                .IsRequired()
                .HasMaxLength(20) // Maximum length of 20 characters
                .HasColumnType("nvarchar(20)"); // Specify the column type as nvarchar(20)

            // Unique constraint for BookingRef
            modelBuilder.Entity<Booking>()
                .HasIndex(b => b.BookingRef)
                .IsUnique(); // Ensure that BookingRef is unique across all bookings

            // BookingDate configuration
            modelBuilder.Entity<Booking>()
                .Property(b => b.BookingDate) // Booking date is required
                .IsRequired()
                .HasColumnType("datetime"); // Specify the column type as datetime

            // Status configuration
            modelBuilder.Entity<Booking>()
                .Property(b => b.Status) // Status is required
                .IsRequired()
                .HasMaxLength(20) // Maximum length of 20 characters
                .HasColumnType("nvarchar(20)"); // Specify the column type as nvarchar(20)

            // Navigation properties for Booking
            // one-to-many relationship with Ticket
            modelBuilder.Entity<Booking>()
                .HasMany(b => b.Tickets) // A booking can have many tickets
                .WithOne(t => t.Booking) // Each ticket belongs to one booking
                .HasForeignKey(t => t.BookingId) // Foreign key in Ticket table
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for tickets

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Passenger) // Each booking belongs to one passenger
                .WithMany(p => p.Bookings) // A passenger can have many bookings
                .HasForeignKey(b => b.PassengerId) // Foreign key in Booking table
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for passengers


            // CrewMember Entity Configuration
            modelBuilder.Entity<CrewMember>()
                .HasKey(cm => cm.CrewId); // Set CrewMemberId as the primary key

            // CrewMember auto-increment configuration
            modelBuilder.Entity<CrewMember>()
                .Property(cm => cm.CrewId)
                .ValueGeneratedOnAdd() // Configure CrewId to be auto-incremented
                .HasColumnType("int"); // Specify the column type as int

            // FullName configuration
            modelBuilder.Entity<CrewMember>()
                .Property(cm => cm.FullName) // Full name is required
                .IsRequired()
                .HasMaxLength(50) // Maximum length of 50 characters
                .HasColumnType("nvarchar(50)"); // Specify the column type as nvarchar(50)

            // Role configuration
            modelBuilder.Entity<CrewMember>()
                .Property(cm => cm.Role) // Role is required
                .IsRequired()
                .HasMaxLength(30) // Maximum length of 30 characters
                .HasColumnType("nvarchar(30)"); // Specify the column type as nvarchar(30)

            // LicenseNo configuration
            modelBuilder.Entity<CrewMember>()
                .Property(cm => cm.LicenseNo) // License number is required
                .IsRequired()
                .HasMaxLength(20) // Maximum length of 20 characters
                .HasColumnType("nvarchar(20)"); // Specify the column type as nvarchar(20)

            // Navigation properties for CrewMember
            // one-to-many relationship with FlightCrew
            modelBuilder.Entity<CrewMember>()
                .HasMany(cm => cm.FlightCrews) // A crew member can be part of many flight crews
                .WithOne(fc => fc.CrewMember) // Each flight crew has one crew member
                .HasForeignKey(fc => fc.CrewId) // Foreign key in FlightCrew table
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete for flight crews

            // FlightCrew Entity Configuration
            modelBuilder.Entity<FlightCrew>()
                .HasKey(fc => fc.FlightId); // Set FlightCrewId as the primary key

            // FlightCrew auto-increment configuration
            modelBuilder.Entity<FlightCrew>()
                .HasOne(fc => fc.Flight) // Each flight crew belongs to one flight
                .WithMany(f => f.FlightCrews) // A flight can have many flight crews
                .HasForeignKey(fc => fc.FlightId) // Foreign key in FlightCrew table



































































































        }

    }
}
