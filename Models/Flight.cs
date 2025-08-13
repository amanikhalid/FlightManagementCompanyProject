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

    }
}
