using Driving_School_Core.Interfaces;
using Driving_School_DB;
using Driving_School_DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Driving_School_Core.Services
{
    public class ClientService : IClientService
    {
        private readonly DrivingSchoolDbContext _context;
        public ClientService(DrivingSchoolDbContext context)
        {
            _context = context;
        }
        public async Task AddClientAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClientAsync(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Client>> GetAllClientsAsync(string? search = null, string? drivingInstructor = null, string? sortOrder = null)
        {
            IQueryable<Client> queryable = _context.Clients.Include(d => d.DrivingInstructor);
            if (!string.IsNullOrWhiteSpace(search))
            {
                queryable = queryable.Where(d => d.FirstName.Contains(search) || d.LastName.Contains(search));
            }
            if (!string.IsNullOrWhiteSpace(drivingInstructor))
            {
                queryable = queryable.Where(d => d.DrivingInstructor.Name.Contains(drivingInstructor));
            }
            switch (sortOrder)
            {
                case "name_asc":
                    queryable = queryable.OrderBy(d => d.FirstName).ThenBy(d => d.LastName);
                    break;
                case "name_desc":
                    queryable = queryable.OrderByDescending(d => d.FirstName).ThenByDescending(d => d.LastName);
                    break;
                case "drivingInstructor":
                    queryable = queryable.OrderBy(d => d.DrivingInstructor.Name).ThenBy(d => d.FirstName);
                    break;
                default:
                    queryable = queryable.OrderBy(d => d.FirstName).ThenBy(d => d.LastName);
                    break;
            }
            return await queryable.ToListAsync();
        }

        public async Task<Client?> GetClientByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client?> GetClientDetailsAsync(int id)
        {
            return await _context.Clients.Include(d => d.DrivingInstructor).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateClientAsync(Client client)
        {
            await _context.SaveChangesAsync();
        }
    }
}
