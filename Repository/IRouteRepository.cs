using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public interface IRouteRepository
    {
        void Add(Route route); // Add a new route record
        void Delete(Route route); // Delete a route record
        IEnumerable<Route> GetAll(); // Get all route records
        Route GetById(int id); // Get a route record by ID
        void Update(Route route); // Update an existing route record
    }
}
