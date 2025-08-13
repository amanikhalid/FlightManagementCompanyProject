using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Models
{
    public class Route
    {
        public int RouteId { get; set; } // Unique identifier for the route

        public int DistanceKm { get; set; } // Distance of the route in kilometers

        // Navigation properties
        // one-to-many relationship with Flight
        public ICollection<Flight> Flights { get; set; } // Collection of flights associated with this route

        // one-to-many relationship with Airport
        public int OriginAirportId { get; set; } // Foreign key to the origin Airport

    }
}
