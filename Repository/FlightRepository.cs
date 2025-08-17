using FlightManagementCompanyProject.Data;
using FlightManagementCompanyProject.Models;
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
    }
}
