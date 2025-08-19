using FlightManagementCompany.Data; // FlightManagementCompany.Data namespace for DbContext
using FlightManagementCompany.DTO; // Data Transfer Objects for flight information
using FlightManagementCompany.Models; // Models for flight entities
using FlightManagementCompany.Repository; // Repository interfaces for data access
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

    }
}
