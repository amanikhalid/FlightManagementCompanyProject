using FlightManagementCompanyProject.Data;
using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public class AircraftMaintenanceRepository : IAircraftMaintenanceRepository 

    {
        private readonly FlightDbContext _context; // Constructor to inject the DbContext

        public AircraftMaintenanceRepository(FlightDbContext context) // Initialize the context
        {
            _context = context;
        }

        public void Add(AircraftMaintenance aircraftMaintenance) // Add a new aircraft maintenance record
        {
            _context.AircraftMaintenances.Add(aircraftMaintenance);
            _context.SaveChanges();
        }

        public void Update(AircraftMaintenance aircraftMaintenance) // Update an existing aircraft maintenance record
        {
            _context.AircraftMaintenances.Update(aircraftMaintenance);
            _context.SaveChanges();
        }

        public void Delete(AircraftMaintenance aircraftMaintenance) // Delete an aircraft maintenance record
        {
            _context.AircraftMaintenances.Remove(aircraftMaintenance);
            _context.SaveChanges();
        }

        public AircraftMaintenance GetById(int id) => _context.AircraftMaintenances.Find(id); // Get an aircraft maintenance record by ID

    }
}
