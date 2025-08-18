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

        public void Update(Route route) // Method to update an existing route record
        {
            _context.Routes.Update(route);
            _context.SaveChanges();
        }

        public void Delete(Route route) // Method to delete a route record
        {
            _context.Routes.Remove(route);
            _context.SaveChanges();
        }

        public Route GetById(int id) => _context.Routes.Find(id); // Method to get a route record by ID
    }
}
