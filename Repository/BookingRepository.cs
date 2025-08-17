using FlightManagementCompanyProject.Data;
using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
   public class BookingRepository : IBookingRepository // Interface implementation for booking repository
    {
        private readonly FlightDbContext _context; // Constructor to inject the DbContext

        public BookingRepository(FlightDbContext context) // Initialize the context
        {
            _context = context;
        }

        public void Add(Booking booking) // Add a new booking record
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public void Update(Booking booking) // Update an existing booking record
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }

        public void Delete(Booking booking) // Delete a booking record
        {
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
        }
    }
}
