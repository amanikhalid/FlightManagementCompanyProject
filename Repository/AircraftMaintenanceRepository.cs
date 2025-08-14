using FlightManagementCompanyProject.Data;
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
    }
}
