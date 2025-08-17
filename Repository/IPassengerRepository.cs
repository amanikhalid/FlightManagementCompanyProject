using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public interface IPassengerRepository
    {
        void Add(Passenger passenger); // Add a new passenger record
        void Delete(Passenger passenger); // Delete a passenger record
        IEnumerable<Passenger> GetAll(); // Get all passenger records
        Passenger GetById(int id); // Get a passenger record by ID

        void Update(Passenger passenger);// Update an existing passenger record
    }
}
