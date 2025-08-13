using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Models
{
    public class Flight
    {
        public int FlightId { get; set; } // Unique identifier for the flight

        public string FlightNumber { get; set; } // Flight number (e.g., AA123)

        public DateTime DepartureUtc { get; set; } // Scheduled departure time in UTC

        public DateTime ArrivalUtc { get; set; } // Scheduled arrival time in UTC

        public string Status { get; set; } // Status of the flight (e.g., scheduled, delayed, cancelled)

        // Navigation properties
        // one-to-many relationship with Ticket
        public ICollection<Ticket> Tickets { get; set; } // Collection of tickets associated with this flight

        // one-to-many relationship with FlightCrew
        public ICollection<FlightCrew> FlightCrews { get; set; } // Collection of flight crews assigned to this flight

        // one-to-many relationship with Aircraft
        public int AircraftId { get; set; } // Foreign key to the Aircraft
        public Aircraft Aircraft { get; set; } // Navigation property to the Aircraft
    }
}
