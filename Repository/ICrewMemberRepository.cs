using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public interface ICrewMemberRepository
    {
        void Add(CrewMember crewMember); // Add a new crew member record
        void Delete(CrewMember crewMember); // Delete a crew member record
        IEnumerable<CrewMember> GetAll(); // Get all crew member records
    }
}
