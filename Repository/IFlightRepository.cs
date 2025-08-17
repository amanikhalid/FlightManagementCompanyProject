using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public interface IFlightRepository
    {
        void Add(Flight flight); // Add a new flight record
        void Delete(Flight flight); // Delete a flight record
    }
}
