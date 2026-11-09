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

        public async Task<List<Car>> GetAllCarsAsync(string? brand = null, string? model = null, int? minYear = null, string? sortOrder = null)
        {
            var query = _context.Cars.AsQueryable();
            if (!string.IsNullOrWhiteSpace(brand))
            {
                query = query.Where(c => c.Brand.Contains(brand));
            }
            if (!string.IsNullOrWhiteSpace(model))
            {
                query = query.Where(c => c.Model.Contains(model));
            }
            if (minYear.HasValue)
            {
                query = query.Where(c => c.Year >= minYear.Value);
            }
            switch (sortOrder)
            {
                case "brand_asc":
                    query = query.OrderBy(c => c.Brand);
                    break;
                case "brand_desc":
                    query = query.OrderByDescending(c => c.Brand);
                    break;
                case "year_asc":
                    query = query.OrderBy(c => c.Year);
                    break;
                case "year_desc":
                    query = query.OrderByDescending(c => c.Year);
                    break;
                default:
                    query = query.OrderBy(c => c.Brand);
                    break;
            }
            return await query.Include(c => c.DrivingInstructorsCars).ThenInclude(dc => dc.DrivingInstructor).ToListAsync();
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
