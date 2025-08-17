using FlightManagementCompanyProject.Data;
using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public class BaggageRepository : IBaggageRepository // Interface implementation for baggage repository
    {
        private readonly FlightDbContext _context; // Constructor to inject the DbContext

        public BaggageRepository(FlightDbContext context) // Initialize the context
        {
            _context = context;
        }

        public void Add(Baggage baggage) // Add a new baggage record
        {
            _context.Baggages.Add(baggage);
            _context.SaveChanges();
        }

        public void Update(Baggage baggage) // Update an existing baggage record
        {
            _context.Baggages.Update(baggage);
            _context.SaveChanges();
        }

        public void Delete(Baggage baggage) // Delete a baggage record
        {
            _context.Baggages.Remove(baggage);
            _context.SaveChanges();
        }

        public Baggage GetById(int id) => _context.Baggages.Find(id); // Get a baggage record by ID
    }
}
