using Driving_School_DB;
using Driving_School_DB.Entities;
using DrivingSchool.ViewModels.DrivingInstructor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchool.Controllers
{
    public class DrivingInstructorController : Controller
    {
        private readonly DrivingSchoolDbContext context;

        public DrivingInstructorController(DrivingSchoolDbContext context)
        {
            this.context = context;
        }



        public async Task<IActionResult> Index()
        {
            var drivingInstructors = await context.DrivingInstructors
                .Where(h => !h.IsGoneOff)
                .ToListAsync();

            var model = new List<IndexVM>();

            foreach (var drivingInstructor in drivingInstructors)
            {
                model.Add(new IndexVM
                {
                    Id = drivingInstructor.Id,
                    Name = drivingInstructor.Name,
                    Email = drivingInstructor.Email,
                    PhoneNumber = drivingInstructor.PhoneNumber,
                    Address = drivingInstructor.Address,
                    Category = drivingInstructor.Category
                });
            }
            return View(model);
        }


        public async Task<IActionResult> Details(int id)
        {
            var drivingInstructor = await context.DrivingInstructors.FindAsync(id);

            if (drivingInstructor == null)
            {
                return NotFound();
            }

            var model = new DetailsVM
            {
                Id = drivingInstructor.Id,
                Name = drivingInstructor.Name,                
                Email = drivingInstructor.Email,
                PhoneNumber = drivingInstructor.PhoneNumber,                
                Address = drivingInstructor.Address,
                Category = drivingInstructor.Category,
                RegisteredOn = drivingInstructor.RegisteredOn
            };

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVM model)
        {
            if (ModelState.IsValid)
            {
                var drivingInstructor = new DrivingInstructor
                {
                    Name = model.Name,                    
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Category = model.Category,
                    RegisteredOn = DateTime.Now,
                    IsGoneOff = false
                };

                context.DrivingInstructors.Add(drivingInstructor);
                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var drivingInstructor = await context.DrivingInstructors.FindAsync(id);
            if (drivingInstructor == null)
            {
                return NotFound();
            }
            var model = new EditVM
            {
                Id = drivingInstructor.Id,
                Name = drivingInstructor.Name,                
                Email = drivingInstructor.Email,
                PhoneNumber = drivingInstructor.PhoneNumber,
                Address = drivingInstructor.Address,
                Category = drivingInstructor.Category
            };

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
                var drivingInstructor = await context.DrivingInstructors.FindAsync(id);

                if (drivingInstructor == null)
                {
                    return NotFound();
                }

                drivingInstructor.Name = model.Name;
                drivingInstructor.Email = model.Email;
                drivingInstructor.PhoneNumber = model.PhoneNumber;
                drivingInstructor.Address = model.Address;
                drivingInstructor.Category = model.Category;
                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var drivingInstructor = await context.DrivingInstructors.FindAsync(id);

            if (drivingInstructor == null)
            {
                return NotFound();
            }

            var model = new DeleteVM
            {
                Id = drivingInstructor.Id,
                Name = drivingInstructor.Name
            };

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drivingInstructor = await context.DrivingInstructors.FindAsync(id);

            if (drivingInstructor != null)
            {
                drivingInstructor.IsGoneOff = true;

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
