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

    }
}
