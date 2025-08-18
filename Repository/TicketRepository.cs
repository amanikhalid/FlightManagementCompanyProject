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
    }
}
