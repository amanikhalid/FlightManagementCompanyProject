using FlightManagementCompanyProject.Data;
using FlightManagementCompanyProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public class FlightRepository : IFlightRepository // Interface implementation for flight repository
    {
        private readonly FlightDbContext _context; // Constructor to inject the DbContext
        public FlightRepository(FlightDbContext context) // Initialize the context
      
        {
            _context = context;
        }

        public void Add(Flight flight) // Add a new flight record
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
        }

        public void Update(Flight flight) // Update an existing flight record
       
        {
            _context.Flights.Update(flight);
            _context.SaveChanges();
        }

        public void Delete(Flight flight) // Delete a flight record
        {
            _context.Flights.Remove(flight);
            _context.SaveChanges();
        }
        public Flight GetById(int id) => _context.Flights.Find(id); // Get a flight record by ID
        public IEnumerable<Flight> GetAll() => _context.Flights.ToList(); // Get all flight records

        public IEnumerable<Flight> GetFlightsByDateRange(DateTime from, DateTime to) // Get flights within a specific date range
        {
            //return _context.Flights
            //    .Where(f => f.DepartureUtc >= from && f.ArrivalUtc <= to)
            //    .ToLi
            return _context.Flights
                .Include(f => f.Tickets)
                .Include(f => f.Route).ThenInclude(r => r.OriginAirport)
                .Include(f => f.Route).ThenInclude(r => r.DestinationAirport)
                .Where(f => f.DepartureUtc.Date >= from.Date &&
                            f.DepartureUtc.Date <= to.Date)
                .ToList();

        }

        public IEnumerable<Flight> GetFlightsByRoute(int routeId) // Get flights by route ID
        {
            return _context.Flights
                .Where(f => f.RouteId == routeId)
                .ToList();
        }

    }
}
