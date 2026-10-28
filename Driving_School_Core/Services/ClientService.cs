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

        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _context.Clients.Include(d => d.DrivingInstructor).ToListAsync();
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
