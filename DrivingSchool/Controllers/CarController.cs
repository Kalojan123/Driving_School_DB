using Driving_School_Core.Interfaces;
using Driving_School_DB.Entities;
using DrivingSchool.ViewModels.Car;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace DrivingSchool.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly IDrivingInstructorService _drivingInstructorService;

        public CarController(ICarService carService, IDrivingInstructorService drivingInstructorService)
        {
            _carService = carService;
            _drivingInstructorService = drivingInstructorService;
        }
        private async Task LoadDrivingInstructors(List<int> selectedDrivingInstructors = null)
        {
            var drivingInstructorsList = await _drivingInstructorService.GetAllDrivingInstructorsAsync();
            var drivingInstructors = drivingInstructorsList.Select(x => new
            {
                x.Id,
                FullName = x.Name
            });
            ViewBag.DrivingInstructors = new MultiSelectList(drivingInstructors, "Id", "FullName", selectedDrivingInstructors);
        }
        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetAllCarsAsync();
            var model = new List<IndexVM>();
            foreach (var car in cars)
            {
                model.Add(new IndexVM
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model,
                    LicensePlate = car.LicensePlate,
                    DrivingInstructorName = string.Join(", ", car.DrivingInstructorsCars.Select(dc => dc.DrivingInstructor.Name))
                });
            }
            return View(model);
        }
        public async Task<IActionResult> Details(int id)
        {
            var car = await _carService.GetCarWithDrivingInstructorsAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var model = new DetailsVM
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Color = car.Color,
                Year = car.Year,
                LicensePlate = car.LicensePlate,
                Mileage = car.Mileage,
                DrivingInstructorName = string.Join(", ", car.DrivingInstructorsCars.Select(dc => dc.DrivingInstructor.Name))
            };
            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            await LoadDrivingInstructors();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateVM model)
        {
            if (ModelState.IsValid)
            {
                var car = new Car
                {
                    Brand = model.Brand,
                    Model = model.Model,
                    Color = model.Color,
                    Year = model.Year,
                    LicensePlate = model.LicensePlate,
                    Mileage = model.Mileage
                };

                foreach (var drivingInstructorId in model.DrivingInstructorIds)
                {
                    car.DrivingInstructorsCars.Add(new DrivingInstructorsCars
                    {
                        DrivingInstructorId = drivingInstructorId
                    });
                }
                await _carService.AddCarAsync(car);
                return RedirectToAction(nameof(Index));
            }
            await LoadDrivingInstructors(model.DrivingInstructorIds);
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carService.GetCarWithDrivingInstructorsAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var model = new EditVM
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Color = car.Color,
                Year = car.Year,
                LicensePlate = car.LicensePlate,
                Mileage = car.Mileage,
                DrivingInstructorIds = car.DrivingInstructorsCars.Select(dc => dc.DrivingInstructorId).ToList()
            };
            await LoadDrivingInstructors(model.DrivingInstructorIds);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditVM model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var car = await _carService.GetCarWithDrivingInstructorsAsync(id);

                if (car == null)
                {
                    return NotFound();
                }

                car.Brand = model.Brand;
                car.Model = model.Model;
                car.Color = model.Color;
                car.Year = model.Year;
                car.LicensePlate = model.LicensePlate;
                car.Mileage = model.Mileage;

                car.DrivingInstructorsCars.Clear();

                foreach (var drivingInstructorId in model.DrivingInstructorIds)
                {
                    car.DrivingInstructorsCars.Add(new DrivingInstructorsCars
                    {
                        DrivingInstructorId = drivingInstructorId,
                        CarId = car.Id
                    });
                }

                await _carService.UpdateCarAsync(car, model.DrivingInstructorIds);
                return RedirectToAction(nameof(Index));
            }

            await LoadDrivingInstructors(model.DrivingInstructorIds);
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var model = new DeleteVM
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model
            };

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _carService.GetCarByIdAsync(id);

            await _carService.DeleteCarAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
