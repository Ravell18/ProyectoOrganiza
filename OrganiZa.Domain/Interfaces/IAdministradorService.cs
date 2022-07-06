using OrganiZa.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrganiZa.Domain.Interfaces
{
    public interface IAdministradorService
    {
        Task AddAdministrador(Administrador administrador);
        Task DeleteAdministrador(int id);
        Task<IEnumerable<Administrador>> GetAdministradores();
        Task<Administrador> GetAdministrador(int id);
        Task UpdateAdministrador(Administrador administrador);
    }
}
