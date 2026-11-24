using Driving_School_DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Driving_School_DB.Configurations
{
    public class DrivingInstructorsCarsConfiguration : IEntityTypeConfiguration<DrivingInstructorsCars>
    {
        public void Configure(EntityTypeBuilder<DrivingInstructorsCars> builder)
        {
            builder.HasKey(dc => new { dc.DrivingInstructorId, dc.CarId });
            builder.HasOne(dc => dc.DrivingInstructor).WithMany(d => d.DrivingInstructorsCars).HasForeignKey(dc => dc.DrivingInstructorId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(dp => dp.Car).WithMany(d => d.DrivingInstructorsCars).HasForeignKey(dp => dp.CarId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
                new DrivingInstructorsCars
                {
                    DrivingInstructorId = 1,
                    CarId = 1
                },
                new DrivingInstructorsCars
                {
                    DrivingInstructorId = 2,
                    CarId = 2
                }
            );
        }
    }
}
