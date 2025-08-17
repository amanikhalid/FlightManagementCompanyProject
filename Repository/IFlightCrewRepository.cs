using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public interface IFlightCrewRepository
    {
        void Add(FlightCrew flightCrew); // Add a new flight crew record
    }
}
