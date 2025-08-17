using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public interface IAircraftMaintenanceRepository
    {
        void Add(AircraftMaintenance aircraftMaintenance); // Add a new aircraft maintenance record
        void Delete(AircraftMaintenance aircraftMaintenance); // Delete an aircraft maintenance record
        IEnumerable<AircraftMaintenance> GetAll(); // Get all aircraft maintenance records
        AircraftMaintenance GetById(int id); // Get an aircraft maintenance record by ID


    }
}
