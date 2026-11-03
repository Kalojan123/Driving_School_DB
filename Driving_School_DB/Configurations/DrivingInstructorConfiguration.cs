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
    public class DrivingInstructorConfiguration : IEntityTypeConfiguration<DrivingInstructor>
    {
        public void Configure(EntityTypeBuilder<DrivingInstructor> builder)
        {
            builder.HasData(
                new DrivingInstructor{
                    Id = 1,
                    Name = "John Doe",
                    Email = "email@mail.com",
                    PhoneNumber = "1234567890",
                    Address = "123 Main St",
                    Category = Enums.Categories.B,
                    RegisteredOn = DateTime.Now,
                    IsGoneOff = false
                },
                new DrivingInstructor
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Email = "mail@email.com",
                    PhoneNumber = "0987654321",
                    Address = "456 Elm St",
                    Category = Enums.Categories.A,
                    RegisteredOn = DateTime.Now,
                    IsGoneOff = false
                }
            );
        }
    }
}
