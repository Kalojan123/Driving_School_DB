using Driving_School_DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DrivingSchool.ViewModels.Client;
using System.Numerics;
using Driving_School_DB.Entities;
using Driving_School_Core.Interfaces;

namespace DrivingSchool.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IDrivingInstructorService _drivingInstructorService;
        public ClientController(IClientService clientService, IDrivingInstructorService drivingInstructorService)
        {
            _clientService = clientService;
            _drivingInstructorService = drivingInstructorService;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.GetAllClientsAsync();

            var model = new List<IndexVM>();

            foreach (var client in clients)
            {
                model.Add(new IndexVM
                {
                    Id = client.Id,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    DrivingInstructor = client.DrivingInstructor.Name
                });
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var client = await _clientService.GetClientDetailsAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            var model = new DetailsVM
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,
                DrivingInstructor = client.DrivingInstructor.Name
            };

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.DrivingInstructors = new SelectList(
            await _drivingInstructorService.GetAllDrivingInstructorsAsync(),
             "Id",
            "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVM model)
        {
            if (ModelState.IsValid)
            {
                var client = new Client
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    DrivingInstructorId = model.DrivingInstructorId
                };

                await _clientService.AddClientAsync(client);

                return RedirectToAction(nameof(Index));
            }           
            ViewBag.DrivingInstructor = new SelectList(
    await _drivingInstructorService.GetAllDrivingInstructorsAsync(),
    "Id",
    "Name");

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            var model = new EditVM
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,
                DrivingInstructorId = client.DrivingInstructorId
            };

            ViewBag.DrivingInstructors = new SelectList(
                    await _drivingInstructorService.GetAllDrivingInstructorsAsync(),
                    "Id",
                    "Name");

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
                var client = await _clientService.GetClientByIdAsync(id);

                if (client == null)
                {
                    return NotFound();
                }
                client.FirstName = model.FirstName;
                client.LastName = model.LastName;
                client.Email = model.Email;
                client.PhoneNumber = model.PhoneNumber;
                client.DrivingInstructorId = model.DrivingInstructorId;
                await _clientService.UpdateClientAsync(client);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DrivingInstructor = new SelectList(
                  await _drivingInstructorService.GetAllDrivingInstructorsAsync(),
                  "Id",
                  "Name");

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            var model = new DeleteVM
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName
            };

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            await _clientService.DeleteClientAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
