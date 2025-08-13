using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Models
{
    public class Aircraft
    {
        public int AircraftId { get; set; } // Unique identifier for the aircraft

        public string TailNumber { get; set; } // Tail number of the aircraft

        public string Model { get; set; } // Model of the aircraft

        public int Capacity { get; set; } // Seating capacity of the aircraft

        // Navigation Propertie
        // one-to-many relationship with Flight
        public ICollection<Flight> Flights { get; set; } 
    }
}
