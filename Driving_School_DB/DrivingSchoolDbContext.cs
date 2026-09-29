using Driving_School_DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driving_School_DB
{
    public class DrivingSchoolDbContext : DbContext
    {
        public DrivingSchoolDbContext(DbContextOptions<DrivingSchoolDbContext> options) : base(options)
        {
        }
        public DbSet<DrivingInstructor> DrivingInstructors { get; set; }
        public DbSet<Client> Clients { get; set; }       
    }
}
