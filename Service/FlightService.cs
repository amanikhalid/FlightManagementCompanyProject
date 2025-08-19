using FlightManagementCompany.Data; // FlightManagementCompany.Data namespace for DbContext
using FlightManagementCompany.DTO; // Data Transfer Objects for flight information
using FlightManagementCompany.Models; // Models for flight entities
using FlightManagementCompany.Repository; // Repository interfaces for data access
using FlightManagementCompanyProject.Data;
using FlightManagementCompanyProject.Models;
using FlightManagementCompanyProject.Repository;
using Microsoft.EntityFrameworkCore; // Entity Framework Core for database operations
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets; // Networking utilities
using System.Reflection.Metadata.Ecma335; // Metadata for ECMA-335
using System.Runtime.Intrinsics.X86; // Intrinsics for x86 architecture
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema; // XML Schema definitions

namespace FlightManagementCompanyProject.Service
{
    public class FlightService
    {
        private readonly FlightRepository _flightRepository; // Repository for flight data access
        private readonly AircraftRepository _aircraftRepository; // Repository for aircraft data access
        private readonly RouteRepository _routeRepository; // Repository for route data access
        private readonly TicketRepository _ticketRepository; // Repository for ticket data access
        private readonly FlightCrewRepository _flightCrewRepository; // Repository for flight crew data access
        private readonly CrewMemberRepository _flightCrewMemberRepository; // Repository for flight crew member data access
        private readonly AircraftMaintenanceRepository _aircraftMaintenanceRepository; // Repository for aircraft maintenance data access
        private readonly AirportRepository _airportRepository; // Repository for airport data access
        private readonly PassengerRepository _passengerRepository; // Repository for passenger data access
        private readonly BookingRepository _bookingRepository; // Repository for booking data access
        private readonly BaggageRepository _baggageRepository; // Repository for baggage data access

        public FlightService(FlightDbContext context) // Constructor to initialize the service with the DbContext
        {

            _flightRepository = new FlightRepository(context); // Initialize flight repository
            _aircraftRepository = new AircraftRepository(context); // Initialize aircraft repository
            _routeRepository = new RouteRepository(context); // Initialize route repository
            _ticketRepository = new TicketRepository(context); // Initialize ticket repository
            _flightCrewRepository = new FlightCrewRepository(context); // Initialize flight crew repository
            _flightCrewMemberRepository = new CrewMemberRepository(context); // Initialize flight crew member repository
            _aircraftMaintenanceRepository = new AircraftMaintenanceRepository(context); // Initialize aircraft maintenance repository
            _airportRepository = new AirportRepository(context); // Initialize airport repository
            _passengerRepository = new PassengerRepository(context); // Initialize passenger repository
            _bookingRepository = new BookingRepository(context); // Initialize booking repository
            _baggageRepository = new BaggageRepository(context); // Initialize baggage repository

        }

        public void CreateSampleData() // Method to create sample data for testing or demonstration purposes
        {
            if (!_aircraftRepository.GetAll().Any()) // Check if there are no aircraft records in the database

            {
                var aircrafts = new List<Aircraft> // 
                {
                      new Aircraft { TailNumber = "A4O-BA", Model = "Boeing 737-800",        Capacity = 162 },
    new Aircraft { TailNumber = "A4O-BB", Model = "Boeing 737 MAX 8",      Capacity = 174 },
    new Aircraft { TailNumber = "A4O-CA", Model = "Boeing 787-9",          Capacity = 296 },
    new Aircraft { TailNumber = "A4O-CB", Model = "Airbus A330-300",       Capacity = 277 },
    new Aircraft { TailNumber = "A4O-CC", Model = "Airbus A320-200",       Capacity = 180 },
      new Aircraft { TailNumber = "A6-EA",  Model = "Airbus A380-800",       Capacity = 517 },
    new Aircraft { TailNumber = "A6-EB",  Model = "Boeing 777-300ER",      Capacity = 360 },
    new Aircraft { TailNumber = "A6-EC",  Model = "Airbus A321neo",        Capacity = 200 },
      new Aircraft { TailNumber = "A7-AL",  Model = "Airbus A350-900",       Capacity = 325 },
    new Aircraft { TailNumber = "A7-BD",  Model = "Boeing 787-8",          Capacity = 242 },
      new Aircraft { TailNumber = "A9C-AD", Model = "Airbus A321-200",       Capacity = 220 },
    new Aircraft { TailNumber = "A9C-AE", Model = "Airbus A320neo",        Capacity = 186 },
      new Aircraft { TailNumber = "HZ-AK",  Model = "Boeing 787-10",         Capacity = 318 },
    new Aircraft { TailNumber = "HZ-AQ",  Model = "Airbus A320-200",       Capacity = 180 },
      new Aircraft { TailNumber = "VT-ANP", Model = "Airbus A320-200",       Capacity = 180 }, // India
    new Aircraft { TailNumber = "9V-SME", Model = "Airbus A350-900",       Capacity = 319 }, // Singapore
    new Aircraft { TailNumber = "G-ZBJD", Model = "Boeing 787-8",          Capacity = 248 }, // UK
    new Aircraft { TailNumber = "CN-RGA", Model = "Boeing 737-800",        Capacity = 162 }, // Morocco
    new Aircraft { TailNumber = "TC-JRV", Model = "Airbus A321-200",       Capacity = 215 }, // Türkiye
    new Aircraft { TailNumber = "PK-LQG", Model = "Boeing 737 MAX 8",      Capacity = 174 }  // Indonesia
};
                foreach (var aircraft in aircrafts) // Iterate through each aircraft in the list
                {
                    _aircraftRepository.Add(aircraft);
                }

            }

            // 2. Airport data creation
            if (!_airportRepository.GetAll().Any())
            {
                var airports = new List<Airport> 
                {
                      new Airport { IATA = "MCT", Name = "Muscat International Airport",    City = "Muscat",  Country = "Oman",                 TimeZone = "Asia/Muscat" },
        new Airport { IATA = "SLL", Name = "Salalah International Airport",   City = "Salalah", Country = "Oman",                 TimeZone = "Asia/Muscat" },
        new Airport { IATA = "OHS", Name = "Sohar Airport",                   City = "Sohar",   Country = "Oman",                 TimeZone = "Asia/Muscat" },
        new Airport { IATA = "KHS", Name = "Khasab Airport",                  City = "Khasab",  Country = "Oman",                 TimeZone = "Asia/Muscat" },
        new Airport { IATA = "DQM", Name = "Duqm International Airport",      City = "Duqm",    Country = "Oman",                 TimeZone = "Asia/Muscat" },
          new Airport { IATA = "DXB", Name = "Dubai International Airport",     City = "Dubai",   Country = "United Arab Emirates", TimeZone = "Asia/Dubai" },
        new Airport { IATA = "AUH", Name = "Abu Dhabi International Airport", City = "Abu Dhabi", Country = "United Arab Emirates", TimeZone = "Asia/Dubai" },
        new Airport { IATA = "DOH", Name = "Hamad International Airport",     City = "Doha",    Country = "Qatar",                TimeZone = "Asia/Qatar" },
        new Airport { IATA = "BAH", Name = "Bahrain International Airport",   City = "Manama",  Country = "Bahrain",              TimeZone = "Asia/Bahrain" },
        new Airport { IATA = "RUH", Name = "King Khalid International",       City = "Riyadh",  Country = "Saudi Arabia",         TimeZone = "Asia/Riyadh" }
    };

                foreach (var ap in airports) // Iterate through each airport in the list
                    _airportRepository.Add(ap);

            }

            // 3. Route data creation
            if (!_routeRepository.GetAll().Any())
            {
                var routes = new List<Route>
                {
                      new Route { DistanceKm = 870, OriginAirportId = 1, DestinationAirportId = 2 },  
        new Route { DistanceKm = 200, OriginAirportId = 1, DestinationAirportId = 3 }, 
        new Route { DistanceKm = 270, OriginAirportId = 1, DestinationAirportId = 4 },  
        new Route { DistanceKm = 540, OriginAirportId = 1, DestinationAirportId = 5 },  
        new Route { DistanceKm = 870, OriginAirportId = 2, DestinationAirportId = 1 },  
        new Route { DistanceKm = 200, OriginAirportId = 3, DestinationAirportId = 1 },  
        new Route { DistanceKm = 270, OriginAirportId = 4, DestinationAirportId = 1 },  
        new Route { DistanceKm = 540, OriginAirportId = 5, DestinationAirportId = 1 },
                 new Route { DistanceKm = 340, OriginAirportId = 1, DestinationAirportId = 6 },  
        new Route { DistanceKm = 430, OriginAirportId = 1, DestinationAirportId = 7 },  
        new Route { DistanceKm = 700, OriginAirportId = 1, DestinationAirportId = 8 },  
        new Route { DistanceKm = 850, OriginAirportId = 1, DestinationAirportId = 9 },  
        new Route { DistanceKm = 1050,OriginAirportId = 1, DestinationAirportId = 10 }, 
                }


                }   }


} 
