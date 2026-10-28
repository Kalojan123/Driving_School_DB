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
    public class DrivingInstructorService : IDrivingInstructorService
    {
        private readonly DrivingSchoolDbContext _context;
        public DrivingInstructorService(DrivingSchoolDbContext context)
        {
            _context = context;
        }
        public async Task AddDrivingInstructorAsync(DrivingInstructor drivingInstructor)
        {
            _context.DrivingInstructors.Add(drivingInstructor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDrivingInstructorAsync(int id)
        {
            var drivingInstructor = await _context.DrivingInstructors.Include(d => d.Clients).Include(d => d.DrivingInstructorsCars).ThenInclude(d => d.Car).FirstOrDefaultAsync(d => d.Id == id);
            if (drivingInstructor != null)
            {
                drivingInstructor.IsGoneOff = false;
                if (drivingInstructor.DrivingInstructorsCars.Any())
                {
                    _context.DrivingInstructorsCars.RemoveRange(drivingInstructor.DrivingInstructorsCars);
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DrivingInstructor>> GetAllDrivingInstructorsAsync()
        {
            return await _context.DrivingInstructors.Where(d => !d.IsGoneOff).ToListAsync();
        }

        public async Task<DrivingInstructor?> GetDrivingInstructorByIdAsync(int id)
        {
            return await _context.DrivingInstructors.FindAsync(id);
        }
        public async Task UpdateDrivingInstructorAsync(DrivingInstructor drivingInstructor)
        {
            await _context.SaveChangesAsync();
        }
    }
}
