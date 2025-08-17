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

        public CrewMember GetById(int id) => _context.CrewMembers.Find(id); // Get a crew member record by ID

        public IEnumerable<CrewMember> GetAll() => _context.CrewMembers.ToList(); // Get all crew member records

        public IEnumerable<CrewMember> GetCrewMembersByRole(string role) // Get crew members by their role
        {
            return _context.CrewMembers // Access the CrewMembers DbSet
                   .Where(cm => cm.Role.ToString().Equals(role, StringComparison.OrdinalIgnoreCase)) // Filter by Role -- .Equals(role, StringComparison.OrdinalIgnoreCase) compares the role ignoring case.
                .ToList();

        }

        public IEnumerable<CrewMember> GetAvailableCrew(DateTime departureDate) // Get available crew members for a specific departure date

        {
            return _context.CrewMembers
                    .Where(cm => !cm.FlightCrews // Check if the crew member is not assigned to any flight crew
        }





    }
}
