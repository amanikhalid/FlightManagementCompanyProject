using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Models
{
    public class Airport
    {
        public int AirportId { get; set; } // Unique identifier for the airport

        public string IATA { get; set; } // IATA code of the airport

        public string City { get; set; } // City where the airport is located
    }
}
