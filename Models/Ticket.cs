using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Models
{
    public class Ticket
    {
        public int TicketId { get; set; } // Unique identifier for the ticket
       
        public string SeatNumber { get; set; } // Seat number assigned to the ticket

        public decimal Fare { get; set; } // Fare amount for the ticket

        public bool CheckedIn { get; set; } // Indicates if the passenger has checked in for the flight

        // Navigation properties
        // one-to-many relationship with Booking 
        public int BookingId { get; set; } // Foreign key to the Booking
    }
}
