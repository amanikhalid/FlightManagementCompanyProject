using FlightManagementCompanyProject.Data;
using FlightManagementCompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Repository
{
    public class CrewMemberRepository : ICrewMemberRepository // Interface implementation for crew member repository
    {

        private readonly FlightDbContext _context; // Constructor to inject the DbContext

        public CrewMemberRepository(FlightDbContext context) // Initialize the context
        {
            _context = context;
        }

        public void Add(CrewMember crewMember) // Add a new crew member record
        {
            _context.CrewMembers.Add(crewMember);
            _context.SaveChanges();
        }

        public void Update(CrewMember crewMember) // Update an existing crew member record
        {
            _context.CrewMembers.Update(crewMember);
            _context.SaveChanges();
        }

        public void Delete(CrewMember crewMember) // Delete a crew member record
        {
            _context.CrewMembers.Remove(crewMember);
            _context.SaveChanges();
        }
    }
}
