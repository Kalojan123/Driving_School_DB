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
        public DbSet<Car> Cars { get; set; }
        public DbSet<DrivingInstructorsCars> DrivingInstructorsCars { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DrivingInstructorsCars>().HasKey(dc => new { dc.DrivingInstructorId, dc.CarId });
            modelBuilder.Entity<DrivingInstructorsCars>().HasOne(dc => dc.DrivingInstructor).WithMany(d => d.DrivingInstructorsCars).HasForeignKey(dc => dc.DrivingInstructorId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DrivingInstructorsCars>().HasOne(dc => dc.Car).WithMany(c => c.DrivingInstructorsCars).HasForeignKey(dc => dc.CarId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
