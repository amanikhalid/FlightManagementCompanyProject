using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Models
{
    public class FlightCrew
    {
        public string RoleOnFlight { get; set; } // Role of the crew member on the flight (e.g., pilot, co-pilot, flight attendant)

        // Navigation properties
        // one-to-many relationship with Flight
        public int FlightId { get; set; } // Foreign key to the Flight
    }
}
