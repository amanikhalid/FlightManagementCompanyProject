using FlightManagementCompanyProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public class RouteRepository : IRouteRepository // Interface implementation for RouteRepository
    {
        private readonly FlightDbContext _context; // Constructor to initialize the DbContext

        public RouteRepository(FlightDbContext context) // Constructor to initialize the DbContext
        {
            _context = context;
        }

    }
}
