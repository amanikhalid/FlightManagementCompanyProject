using FlightManagementCompanyProject.Data;
using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public class FlightCrewRepository
    {
        private readonly FlightDbContext _context; // Constructor to inject the DbContext
        public FlightCrewRepository(FlightDbContext context) // Initialize the context
       
        {
            _context = context;
        }

        public void Add(FlightCrew flightCrew) // Add a new flight crew record
        {
            _context.FlightCrews.Add(flightCrew);
            _context.SaveChanges();
        }
    }
}
