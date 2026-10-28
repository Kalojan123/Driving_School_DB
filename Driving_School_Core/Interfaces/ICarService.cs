using Driving_School_DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driving_School_Core.Interfaces
{
    public interface ICarService
    {
        Task<List<Car>> GetAllCarsAsync();
        Task<Car?> GetCarByIdAsync(int id);
        Task<Car?> GetCarWithDrivingInstructorsAsync(int id);
        Task AddCarAsync(Car car);
        Task UpdateCarAsync(Car car, List<int> drivingInstructorIds);
        Task DeleteCarAsync(int id);
    }
}
