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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasData(
                new Client
                {
                    Id = 1,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "email@gmail.com",
                    PhoneNumber = "1234567890",
                    DrivingInstructorId = 1
                },
                new Client
                {
                    Id = 2,
                    FirstName = "Bob",
                    LastName = "Smith",
                    Email = "mail@gmail.com",
                    PhoneNumber = "1324657890",
                    DrivingInstructorId = 2
                }
            );
        }
    }
}
