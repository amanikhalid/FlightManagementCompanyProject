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
                    new Aircraft { TailNumber = "A4O-BA", Model = "Boeing 737-800", Capacity = 162 },
                    new Aircraft { TailNumber = "A4O-BB", Model = "Boeing 737 MAX 8", Capacity = 174 },
                    new Aircraft { TailNumber = "A4O-CA", Model = "Boeing 787-9", Capacity = 296 },
                    new Aircraft { TailNumber = "A4O-CB", Model = "Airbus A330-300", Capacity = 277 },
                    new Aircraft { TailNumber = "A4O-CC", Model = "Airbus A320-200", Capacity = 180 },
                    new Aircraft { TailNumber = "A6-EA", Model = "Airbus A380-800", Capacity = 517 },
                    new Aircraft { TailNumber = "A6-EB", Model = "Boeing 777-300ER", Capacity = 360 },
                    new Aircraft { TailNumber = "A6-EC", Model = "Airbus A321neo", Capacity = 200 },
                    new Aircraft { TailNumber = "A7-AL", Model = "Airbus A350-900", Capacity = 325 },
                    new Aircraft { TailNumber = "A7-BD", Model = "Boeing 787-8", Capacity = 242 },
                    new Aircraft { TailNumber = "A9C-AD", Model = "Airbus A321-200", Capacity = 220 },
                    new Aircraft { TailNumber = "A9C-AE", Model = "Airbus A320neo", Capacity = 186 },
                    new Aircraft { TailNumber = "HZ-AK", Model = "Boeing 787-10", Capacity = 318 },
                    new Aircraft { TailNumber = "HZ-AQ", Model = "Airbus A320-200", Capacity = 180 },
                    new Aircraft { TailNumber = "VT-ANP", Model = "Airbus A320-200", Capacity = 180 }, // India
                    new Aircraft { TailNumber = "9V-SME", Model = "Airbus A350-900", Capacity = 319 }, // Singapore
                    new Aircraft { TailNumber = "G-ZBJD", Model = "Boeing 787-8", Capacity = 248 }, // UK
                    new Aircraft { TailNumber = "CN-RGA", Model = "Boeing 737-800", Capacity = 162 }, // Morocco
                    new Aircraft { TailNumber = "TC-JRV", Model = "Airbus A321-200", Capacity = 215 }, // Türkiye
                    new Aircraft { TailNumber = "PK-LQG", Model = "Boeing 737 MAX 8", Capacity = 174 }  // Indonesia
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
                    new Airport { IATA = "MCT", Name = "Muscat International Airport", City = "Muscat", Country = "Oman", TimeZone = "Asia/Muscat" },
                    new Airport { IATA = "SLL", Name = "Salalah International Airport", City = "Salalah", Country = "Oman", TimeZone = "Asia/Muscat" },
                    new Airport { IATA = "OHS", Name = "Sohar Airport", City = "Sohar", Country = "Oman", TimeZone = "Asia/Muscat" },
                    new Airport { IATA = "KHS", Name = "Khasab Airport", City = "Khasab", Country = "Oman", TimeZone = "Asia/Muscat" },
                    new Airport { IATA = "DQM", Name = "Duqm International Airport", City = "Duqm", Country = "Oman", TimeZone = "Asia/Muscat" },
                    new Airport { IATA = "DXB", Name = "Dubai International Airport", City = "Dubai", Country = "United Arab Emirates", TimeZone = "Asia/Dubai" },
                    new Airport { IATA = "AUH", Name = "Abu Dhabi International Airport", City = "Abu Dhabi", Country = "United Arab Emirates", TimeZone = "Asia/Dubai" },
                    new Airport { IATA = "DOH", Name = "Hamad International Airport", City = "Doha", Country = "Qatar", TimeZone = "Asia/Qatar" },
                    new Airport { IATA = "BAH", Name = "Bahrain International Airport", City = "Manama", Country = "Bahrain", TimeZone = "Asia/Bahrain" },
                    new Airport { IATA = "RUH", Name = "King Khalid International", City = "Riyadh", Country = "Saudi Arabia", TimeZone = "Asia/Riyadh" }
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
                    new Route { DistanceKm = 1050, OriginAirportId = 1, DestinationAirportId = 10 },
                    new Route { DistanceKm = 340, OriginAirportId = 6, DestinationAirportId = 1 },
                    new Route { DistanceKm = 430, OriginAirportId = 7, DestinationAirportId = 1 },
                    new Route { DistanceKm = 700, OriginAirportId = 8, DestinationAirportId = 1 },
                    new Route { DistanceKm = 850, OriginAirportId = 9, DestinationAirportId = 1 },
                    new Route { DistanceKm = 1050, OriginAirportId = 10, DestinationAirportId = 1 },
                    new Route { DistanceKm = 380, OriginAirportId = 6, DestinationAirportId = 8 },
                    new Route { DistanceKm = 380, OriginAirportId = 8, DestinationAirportId = 6 }
                };

                foreach (var r in routes) // Iterate through each route in the list
                    _routeRepository.Add(r);
            }

            // 4. Passenger data creation
            if (!_passengerRepository.GetAll().Any())
            {
                var passengers = new List<Passenger>
                {
                      new Passenger { FullName = "Salim Al‑Salami",        PassportNo = "OM100001", Nationality = "Omani", DOB = new DateTime(1990, 1, 1) },
        new Passenger { FullName = "Ali Al‑Sinani",          PassportNo = "OM100002", Nationality = "Omani", DOB = new DateTime(1992, 2, 2) },
        new Passenger { FullName = "Fatima Al‑Habsi",        PassportNo = "OM100003", Nationality = "Omani", DOB = new DateTime(1995, 3, 3) },
        new Passenger { FullName = "Mohammed Al‑Balushi",    PassportNo = "OM100004", Nationality = "Omani", DOB = new DateTime(1988, 4, 4) },
        new Passenger { FullName = "Aisha Al‑Harthy",        PassportNo = "OM100005", Nationality = "Omani", DOB = new DateTime(1993, 5, 5) },
        new Passenger { FullName = "Othman Al‑Sinani",       PassportNo = "OM100006", Nationality = "Omani", DOB = new DateTime(1990, 7, 31) },
        new Passenger { FullName = "Nadia Al‑Rawahi",        PassportNo = "OM100007", Nationality = "Omani", DOB = new DateTime(1986, 10, 1) },
        new Passenger { FullName = "Layla Al‑Zadjali",       PassportNo = "OM100008", Nationality = "Omani", DOB = new DateTime(1996, 8, 25) },
        new Passenger { FullName = "Huda Al‑Shibli",         PassportNo = "OM100009", Nationality = "Omani", DOB = new DateTime(1998, 3, 22) },
        new Passenger { FullName = "Yousuf Al‑Hinai",        PassportNo = "OM100010", Nationality = "Omani", DOB = new DateTime(1989, 3, 18) },
          new Passenger { FullName = "Fahad Al‑Mutairi",       PassportNo = "SA200011", Nationality = "Saudi",   DOB = new DateTime(1986, 9, 14) },
        new Passenger { FullName = "Hamad Al‑Marri",         PassportNo = "QA200012", Nationality = "Qatari",  DOB = new DateTime(1990, 8, 19) },
        new Passenger { FullName = "Khalifa Al‑Mazrouei",    PassportNo = "AE200013", Nationality = "Emirati", DOB = new DateTime(1985, 12, 4) },
        new Passenger { FullName = "Maryam Al‑Khalifa",      PassportNo = "BH200014", Nationality = "Bahraini",DOB = new DateTime(1994, 2, 27) },
        new Passenger { FullName = "Saad Al‑Otaibi",         PassportNo = "SA200015", Nationality = "Saudi",   DOB = new DateTime(1979, 1, 29) },
          new Passenger { FullName = "John Smith",             PassportNo = "GB300016", Nationality = "British", DOB = new DateTime(1974, 5, 15) },
        new Passenger { FullName = "Emily Johnson",          PassportNo = "US300017", Nationality = "American",DOB = new DateTime(1988, 9, 23) },
        new Passenger { FullName = "Rajesh Kumar",           PassportNo = "IN300018", Nationality = "Indian",  DOB = new DateTime(1978, 9, 3) },
        new Passenger { FullName = "Priya Singh",            PassportNo = "IN300019", Nationality = "Indian",  DOB = new DateTime(1995, 2, 25) },
        new Passenger { FullName = "Hiroshi Tanaka",         PassportNo = "JP300020", Nationality = "Japanese",DOB = new DateTime(1975, 12, 5) }
                };


                foreach (var passenger in passengers) // Iterate through each passenger in the list
                {
                    _passengerRepository.Add(passenger);
                }

            }

            // 5. Booking data creation
            if (!_bookingRepository.GetAll().Any())
            {
                var bookings = new List<Booking>
                {
                    new Booking { BookingRef = "BK0001", BookingDate = new DateTime(2025, 8, 10), Status = BookingStatus.Confirmed, PassengerId = 1 },
                    new Booking { BookingRef = "BK0002", BookingDate = new DateTime(2025, 8, 11), Status = BookingStatus.Cancelled, PassengerId = 2 },
                    new Booking { BookingRef = "BK0003", BookingDate = new DateTime(2025, 8, 12), Status = BookingStatus.Confirmed, PassengerId = 3 },
                    new Booking { BookingRef = "BK0004", BookingDate = new DateTime(2025, 8, 13), Status = BookingStatus.Pending, PassengerId = 4 },
                    new Booking { BookingRef = "BK0005", BookingDate = new DateTime(2025, 8, 14), Status = BookingStatus.Confirmed, PassengerId = 5 },
                    new Booking { BookingRef = "BK0006", BookingDate = new DateTime(2025, 8, 15), Status = BookingStatus.Cancelled, PassengerId = 6 },
                    new Booking { BookingRef = "BK0007", BookingDate = new DateTime(2025, 8, 16), Status = BookingStatus.Confirmed, PassengerId = 7 },
                    new Booking { BookingRef = "BK0008", BookingDate = new DateTime(2025, 8, 17), Status = BookingStatus.Pending, PassengerId = 8 },
                    new Booking { BookingRef = "BK0009", BookingDate = new DateTime(2025, 8, 18), Status = BookingStatus.Confirmed, PassengerId = 9 },
                    new Booking { BookingRef = "BK0010", BookingDate = new DateTime(2025, 8, 19), Status = BookingStatus.Cancelled, PassengerId = 10 },
                    new Booking { BookingRef = "BK0011", BookingDate = new DateTime(2025, 8, 20), Status = BookingStatus.Confirmed, PassengerId = 11 },
                    new Booking { BookingRef = "BK0012", BookingDate = new DateTime(2025, 8, 21), Status = BookingStatus.Confirmed, PassengerId = 12 },
                    new Booking { BookingRef = "BK0013", BookingDate = new DateTime(2025, 8, 22), Status = BookingStatus.Pending, PassengerId = 13 },
                    new Booking { BookingRef = "BK0014", BookingDate = new DateTime(2025, 8, 23), Status = BookingStatus.Confirmed, PassengerId = 14 },
                    new Booking { BookingRef = "BK0015", BookingDate = new DateTime(2025, 8, 24), Status = BookingStatus.Cancelled, PassengerId = 15 },
                    new Booking { BookingRef = "BK0016", BookingDate = new DateTime(2025, 8, 25), Status = BookingStatus.Confirmed, PassengerId = 16 },
                    new Booking { BookingRef = "BK0017", BookingDate = new DateTime(2025, 8, 26), Status = BookingStatus.Confirmed, PassengerId = 17 },
                    new Booking { BookingRef = "BK0018", BookingDate = new DateTime(2025, 8, 27), Status = BookingStatus.Pending, PassengerId = 18 },
                    new Booking { BookingRef = "BK0019", BookingDate = new DateTime(2025, 8, 28), Status = BookingStatus.Confirmed, PassengerId = 19 },
                    new Booking { BookingRef = "BK0020", BookingDate = new DateTime(2025, 8, 29), Status = BookingStatus.Cancelled, PassengerId = 20 }
                };

                foreach (var booking in bookings) // Iterate through each booking in the list
                {
                    _bookingRepository.Add(booking);
                }


            }

            // 6. Aircraft Maintenance data creation
            if (!_aircraftMaintenanceRepository.GetAll().Any())
            {
                new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 05), Type = "A-Check", Notes = "Line check at MCT; no findings.", AircraftId = 1 }, 
        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 07), Type = "Engine Inspection", Notes = "Boroscope on #2; within limits.", AircraftId = 2 }, 
        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 09), Type = "Cabin Refurbishment", Notes = "Seat covers replaced; LED strip fix.", AircraftId = 3 }, 
        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 10), Type = "Landing Gear Service", Notes = "Nose gear bushings changed.", AircraftId = 4 }, 
        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 12), Type = "Hydraulic System Check", Notes = "Reservoir topped; minor seepage monitored.", AircraftId = 5 }, 
        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 14), Type = "Software Update", Notes = "FMS DB + navdata updated to AIRAC 2508.", AircraftId = 6 }, 
        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 16), Type = "Brake Replacement", Notes = "Main gear brakes replaced (2 wheels).", AircraftId = 7 }, 
        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 18), Type = "Fuel System Inspection", Notes = "Filter change; leak check OK.", AircraftId = 8 }, 
        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 21), Type = "Oxygen System Service", Notes = "Crew O2 bottles serviced; regulator test passed.", AircraftId = 9 }, 
        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 23), Type = "IFE Upgrade", Notes = "Content refresh + minor screen swaps at DOH.", AircraftId = 10 }, 
        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 26), Type = "Wing Inspection", Notes = "NDT on upper skin panels; no cracks detected.", AircraftId = 11 }, 
        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 29), Type = "Pitot-Static Test", Notes = "Alt/AS checks within tolerance; cert issued.", AircraftId = 12 }
        }; 
    }
            


    }
}


    

