using FlightManagementCompanyProject.Data;
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
    }
}
