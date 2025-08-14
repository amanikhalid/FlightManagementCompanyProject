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

        public Aircraft GetById(int id) => _context.Aircrafts.Find(id); // Get an aircraft record by ID

        public IEnumerable<Aircraft> GetAll() => _context.Aircrafts.ToList(); // Get all aircraft records

        public IEnumerable<Aircraft> GetDueForMaintenance(DateTime beforeDate) // Method to get aircraft due for maintenance before a specific date
        {

            return _context.Aircrafts // Query the Aircrafts DbSet
                    .Include(a => a.AircraftMaintenances) // Include related AircraftMaintenances
                    .Where(a => a.AircraftMaintenances.Any(m => m.MaintenanceDate <= beforeDate)) // Filter aircraft that have any maintenance record before the specified date
                    .ToList(); // Convert the result to a list and return it
        }


    }
}
