using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public interface IBookingRepository
    {
        void Add(Booking booking); // Add a new booking record
        void Delete(Booking booking); // Delete a booking record
        IEnumerable<Booking> GetAll(); // Get all booking records
        IEnumerable<Booking> GetBookingsByDateRange(DateTime from, DateTime to); // Get bookings within a specific date range
        Booking GetById(int id); // Get a booking record by ID
        void Update(Booking booking); // Update an existing booking record
    }
}
