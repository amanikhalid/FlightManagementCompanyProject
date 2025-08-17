using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public interface IAircraftRepository
    {
        void Add(Aircraft aircraft); // Add a new aircraft record
        void Delete(Aircraft aircraft); // Delete an aircraft record
        IEnumerable<Aircraft> GetAll(); // Get all aircraft records
        Aircraft GetById(int id); // Get an aircraft record by ID
        IEnumerable<Aircraft> GetDueForMaintenance(DateTime beforeDate); // Get aircraft due for maintenance before a specific date
    }
}
