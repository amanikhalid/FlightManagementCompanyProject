using FlightManagementCompanyProject.Data;
using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public class AircraftRepository : IAircraftRepository // Interface implementation for aircraft repository

    {
        private readonly FlightDbContext _context; // Constructor to inject the DbContext
        public AircraftRepository(FlightDbContext context) // Initialize the context
        {
            _context = context;
        }

        public void Add(Aircraft aircraft) // Add a new aircraft record
        {
            _context.Aircrafts.Add(aircraft);
            _context.SaveChanges();
        }

        public void Update(Aircraft aircraft) // Update an existing aircraft record
     
        {
            _context.Aircrafts.Update(aircraft);
            _context.SaveChanges();
        }

        public void Delete(Aircraft aircraft) // Delete an aircraft record
       
        {
            _context.Aircrafts.Remove(aircraft);
            _context.SaveChanges();
        }
    }
}
