using FlightManagementCompanyProject.Data;
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
    }
}
