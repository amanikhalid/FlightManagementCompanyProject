using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public interface IBaggageRepository
    {
        void Add(Baggage baggage); // Add a new baggage record
        void Delete(Baggage baggage); // Delete a baggage record
        IEnumerable<Baggage> GetAll(); // Get all baggage records
        Baggage GetById(int id); // Get a baggage record by ID
    }
}
