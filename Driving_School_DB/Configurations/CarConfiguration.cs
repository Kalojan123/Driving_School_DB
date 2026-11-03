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
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(
                new Car
                {
                    Id = 1,
                    Brand = "Toyota",
                    Model = "Corolla",
                    Color = "Red",
                    Year = 2020,
                    LicensePlate = "ABC123",
                    Mileage = 15000
                },
                new Car
                {
                    Id = 2,
                    Brand = "Honda",
                    Model = "Civic",
                    Color = "Blue",
                    Year = 2019,
                    LicensePlate = "XYZ789",
                    Mileage = 20000
                }
            );
        }
    }
}
