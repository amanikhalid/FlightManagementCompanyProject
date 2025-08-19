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
                var aircrafts = new List<Aircraft>
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






                }



        }   }  

       
    }
}
