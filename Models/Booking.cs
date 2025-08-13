using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Models
{
    public class Booking
    {
        public int BookingId { get; set; } // Unique identifier for the booking 

        public string BookingRef { get; set; } // Reference number for the booking

        public DateTime BookingDate { get; set; } // Date when the booking was made

        public string Status { get; set; } // Status of the booking (e.g., confirmed, cancelled)

        // Navigation properties
        // one-to-many relationship with Ticket
        public ICollection<Ticket> Tickets { get; set; } // Collection of tickets associated with this booking

        // one-to-many relationship with Passenger
        public int PassengerId { get; set; } // Foreign key to the Passenger
    }
}
