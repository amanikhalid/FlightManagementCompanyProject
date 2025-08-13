using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Models
{
    public class Ticket
    {
        public int TicketId { get; set; } // Unique identifier for the ticket
       
        public string SeatNumber { get; set; } // Seat number assigned to the ticket

        public decimal Fare { get; set; } // Fare amount for the ticket
    }
}
