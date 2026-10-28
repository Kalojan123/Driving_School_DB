using Driving_School_Core.Interfaces;
using Driving_School_DB;
using Driving_School_DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driving_School_Core.Services
{
    public class CarService : ICarService
    {
        private readonly DrivingSchoolDbContext _context;
        public CarService(DrivingSchoolDbContext context)
        {
            _context = context;
        }
        public async Task AddCarAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(int id)
        {
            var car = await _context.Cars.Include(c => c.DrivingInstructorsCars).FirstOrDefaultAsync(c => c.Id == id);
            if (car != null)
            {
                _context.DrivingInstructorsCars.RemoveRange(car.DrivingInstructorsCars);
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _context.Cars.Include(c => c.DrivingInstructorsCars).ThenInclude(dc => dc.DrivingInstructor).ToListAsync();
        }

        public async Task<Car?> GetCarByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<Car?> GetCarWithDrivingInstructorsAsync(int id)
        {
            return await _context.Cars.Include(c => c.DrivingInstructorsCars).ThenInclude(dc => dc.DrivingInstructor).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateCarAsync(Car car, List<int> drivingInstructorIds)
        {
            car.DrivingInstructorsCars.Clear();
            foreach (var drivingInstructorId in drivingInstructorIds.Distinct())
            {
                car.DrivingInstructorsCars.Add(new DrivingInstructorsCars
                {
                    DrivingInstructorId = drivingInstructorId,
                    CarId = car.Id
                });
            }
            await _context.SaveChangesAsync();
        }
    }
}
