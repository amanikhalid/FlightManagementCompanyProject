using FlightManagementCompanyProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompanyProject.Data
{
    public class FlightDbContext : DbContext // DbContext for the Flight Management Company Project
    {
        public DbSet<Aircraft> Aircrafts { get; set; } // DbSet for Aircraft entities
        public DbSet<AircraftMaintenance> AircraftMaintenances { get; set; } // DbSet for AircraftMaintenance entities
    }
}
