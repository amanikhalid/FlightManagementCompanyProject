using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Models
{
    public class Passenger
    {
      public int PassengerId { get; set; } // Unique identifier for the passenger

        public string FullName { get; set; } // Full name of the passenger

        public string PassportNo { get; set; } // Passport number of the passenger
    }
}
