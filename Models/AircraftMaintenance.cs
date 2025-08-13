using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Models
{
    public class AircraftMaintenance
    {
        public int MaintenanceId { get; set; } // Unique identifier for the maintenance record

        public DateTime MaintenanceDate { get; set; } // Date of the maintenance

        public string Type { get; set; } // Type of maintenance (e.g., routine, emergency)

        public string Notes { get; set; } // Additional notes or details about the maintenance

        // Navigation properties 
        // one-to-many relationship with Aircraft
        public int AircraftId { get; set; } // Foreign key to the Aircraft

        public Aircraft Aircraft { get; set; } // Navigation property to the Aircraft
    }
}
