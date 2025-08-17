using FlightManagementCompanyProject.Data;
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
    }
}
