using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Models
{
    public class Baggage
    {
        public int BaggageId { get; set; } // Unique identifier for the baggage item

        public decimal WeightKg { get; set; } // Weight of the baggage in kilograms

        public string TagNumber { get; set; } // Tag number for the baggage item

        // Navigation properties
        // one-to-many relationship with Ticket
        public int TicketId { get; set; } // Foreign key to the Ticket
        public Ticket Ticket { get; set; } // Navigation property to the Ticket 


    }
}
