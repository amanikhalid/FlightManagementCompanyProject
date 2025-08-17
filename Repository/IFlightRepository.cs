using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public interface IFlightRepository
    {
        void Add(Flight flight); // Add a new flight record
        void Delete(Flight flight); // Delete a flight record
        IEnumerable<Flight> GetAll(); // Get all flight records
        Flight GetById(int id); // Get a flight record by ID
        Flight GetByIdIncludingDetails(int id); // Get a flight record by ID including related details
        Flight GetFlightByTicket(int ticketId); // Get the flight associated with a specific ticket
        IEnumerable<Flight> GetFlightsByDateRange(DateTime from, DateTime to); // Get flights within a specific date range
        IEnumerable<Flight> GetFlightsByRoute(int routeId); // Get flights by route ID
        void Update(Flight flight); // Update an existing flight record
    }
}
