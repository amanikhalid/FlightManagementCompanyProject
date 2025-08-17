using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public interface IAirportRepository
    {
        void Add(Airport airport); // Add a new airport record
        void Delete(Airport airport); // Delete an airport record
    }
}
