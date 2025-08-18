using FlightManagementCompanyProject.Data;
using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public class PassengerRepository : IPassengerRepository // Interface implementation for PassengerRepository
    {
        private readonly FlightDbContext _context; // Constructor to initialize the DbContext

        public PassengerRepository(FlightDbContext context) // Constructor to initialize the DbContext
        {
            _context = context;
        }

        public void Add(Passenger passenger) // Method to add a new passenger record
      
        {
            _context.Passengers.Add(passenger);
            _context.SaveChanges();
        }

        public void Update(Passenger passenger) // Method to update an existing passenger record
        {
            _context.Passengers.Update(passenger);
            _context.SaveChanges();
        }
        public void Delete(Passenger passenger) // Method to delete a passenger record
       
        {
            _context.Passengers.Remove(passenger);
            _context.SaveChanges();
        }

        public Passenger GetById(int id) => _context.Passengers.Find(id); // Method to get a passenger record by ID

        public IEnumerable<Passenger> GetAll() => _context.Passengers.ToList(); // Method to get all passenger records


    }
}
