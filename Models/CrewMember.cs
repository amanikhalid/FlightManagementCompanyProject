using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Models
{
    public class CrewMember
    {
        public int CrewId { get; set; } // Unique identifier for the crew member

        public string FullName { get; set; } // Full name of the crew member

        public string Role { get; set; } // Role of the crew member (e.g., pilot, flight attendant)

        public string LicenseNo { get; set; } // License number of the crew member, if applicable

        // Navigation properties
        // one-to-many relationship with FlightCrew
        public ICollection<FlightCrew> FlightCrews { get; set; } // Collection of flight crews this crew member is part of

    }
}
