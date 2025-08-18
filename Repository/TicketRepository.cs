using FlightManagementCompanyProject.Data;
using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public class TicketRepository : ITicketRepository // Interface implementation for TicketRepository
    {
        private readonly FlightDbContext _context; // Constructor to initialize the DbContext

        public TicketRepository(FlightDbContext context) // Constructor to initialize the DbContext
        {
            _context = context;
        }

        public void Add(Ticket ticket) // Method to add a new ticket record

        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public void Update(Ticket ticket) // Method to update an existing ticket record
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
        }

        public void Delete(Ticket ticket) // Method to delete a ticket record
        {
            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
        }

        public Ticket GetById(int id) => _context.Tickets.Find(id); // Method to get a ticket record by ID

        public IEnumerable<Ticket> GetAll() => _context.Tickets.ToList(); // Method to get all ticket records

        public IEnumerable<Ticket> GetTicketsByBookingRef(string bookingRef) // Method to get tickets by booking reference
        {
            var bookingId = _context.Bookings // GetBookingIdByBookingRef(bookingRef);
                .Where(b => b.BookingRef == bookingRef) // Get the booking ID by booking reference
                .Select(b => b.BookingId) // Select the BookingId
                .FirstOrDefault(); // Get the first booking ID or default if not found

            return _context.Tickets // GetTicketsByBookingId(bookingId); 
                .Where(t => t.BookingId == bookingId) // Filter tickets by the booking ID
                .ToList(); // Return the list of tickets associated with the booking ID

        }

        public IEnumerable<Ticket> GetTicketsByPassengerId(int passengerId) // Method to get tickets by passenger ID

        {
            var bookingId = _context.Bookings // GetBookingIdByPassengerId(passengerId) 
               

        }
}
