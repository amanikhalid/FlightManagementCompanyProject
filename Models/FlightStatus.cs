using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Models
{
    public enum FlightStatus // Enum to represent the status of a flight
    {
        Scheduled, // Flight is scheduled
        Delayed, // Flight is delayed
        Cancelled, // Flight is cancelled
        InFlight, // Flight is currently in the air

    }
}
