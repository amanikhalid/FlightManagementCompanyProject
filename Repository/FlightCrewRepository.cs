using FlightManagementCompanyProject.Data;
using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public class FlightCrewRepository : IFlightCrewRepository // Interface implementation for flight crew repository
    {
        private readonly FlightDbContext _context; // Constructor to inject the DbContext
        public FlightCrewRepository(FlightDbContext context) // Initialize the context
       
        {
            _context = context;
        }

        public void Add(FlightCrew flightCrew) // Add a new flight crew record
        {
            _context.FlightCrews.Add(flightCrew);
            _context.SaveChanges();
        }

        public void Update(FlightCrew flightCrew) // Update an existing flight crew record
        {
            _context.FlightCrews.Update(flightCrew);
            _context.SaveChanges();
        }

        public void Delete(FlightCrew flightCrew) // Delete a flight crew record
        {
            _context.FlightCrews.Remove(flightCrew);
            _context.SaveChanges();
        }

        public FlightCrew GetById(int id) => _context.FlightCrews.Find(id); // Get a flight crew record by ID

        public IEnumerable<FlightCrew> GetAll() => _context.FlightCrews.ToList(); // Get all flight crew records

    }
}
