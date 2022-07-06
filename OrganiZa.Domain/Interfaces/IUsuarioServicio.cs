using OrganiZa.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrganiZa.Domain.Interfaces
{
    public interface IUsuarioService
    {
        Task AddUsuario(User user);
        Task DeleteUsuario(int id);
        Task<IEnumerable<User>> GetUsuarios();
        Task<User> GetUsuario(int id);
        Task UpdateUsuario(User user);
    }
}
