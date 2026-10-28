using Driving_School_DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Driving_School_Core.Interfaces
{
    public interface IDrivingInstructorService
    {
        Task<List<DrivingInstructor>> GetAllDrivingInstructorsAsync();
        Task<DrivingInstructor?> GetDrivingInstructorByIdAsync(int id);
        Task AddDrivingInstructorAsync(DrivingInstructor drivingInstructor);
        Task UpdateDrivingInstructorAsync(DrivingInstructor drivingInstructor);
        Task DeleteDrivingInstructorAsync(int id);
    }
}
