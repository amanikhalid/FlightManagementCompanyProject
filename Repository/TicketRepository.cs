using FlightManagementCompanyProject.Data;
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
    }
}
