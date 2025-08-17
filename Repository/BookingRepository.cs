using FlightManagementCompanyProject.Data;
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
    }
}
