using Driving_School_DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Driving_School_Core.Interfaces
{
    public interface IClientService
    {
        Task<List<Client>> GetAllClientsAsync(string? search = null, string? drivingInstructor = null, string? sortOrder = null);
        Task<Client?> GetClientByIdAsync(int id);
        Task<Client?> GetClientDetailsAsync(int id);
        Task AddClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(int id);
    }
}
