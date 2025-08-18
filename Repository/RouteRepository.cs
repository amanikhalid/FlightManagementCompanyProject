using FlightManagementCompanyProject.Data;
using FlightManagementCompanyProject.Models;
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

        public void Add(Route route) // Method to add a new route record
        {
            _context.Routes.Add(route);
            _context.SaveChanges();
        }
    }
}
