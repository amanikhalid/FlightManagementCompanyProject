using FlightManagementCompanyProject.Data;
using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public class AirportRepository : IAirportRepository // Interface implementation for airport repository

    {
        private readonly FlightDbContext _context; // Constructor to inject the DbContext
        public AirportRepository(FlightDbContext context) // Initialize the context
        {
            _context = context;
        }

        public void Add(Airport airport) // Add a new airport record
        {
            _context.Airports.Add(airport);
            _context.SaveChanges();
        }

        public void Update(Airport airport) // Update an existing airport record
     
        {
            _context.Airports.Update(airport);
            _context.SaveChanges();
        }

        public void Delete(Airport airport) // Delete an airport record

        {
            _context.Airports.Remove(airport);
            _context.SaveChanges();
        }

        public Airport GetById(int id) => _context.Airports.Find(id); // Get an airport record by ID

        public IEnumerable<Airport> GetAll() => _context.Airports.ToList(); // Get all airport records

    }
}
