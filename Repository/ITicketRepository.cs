using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public interface ITicketRepository
    {
        void Add(Ticket ticket); // Add a new ticket record
        void Delete(Ticket ticket); // Delete a ticket record
        IEnumerable<Ticket> GetAll(); // Get all ticket records

    }
}
