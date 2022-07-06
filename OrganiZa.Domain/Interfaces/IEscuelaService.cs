using OrganiZa.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace OrganiZa.Domain.Interfaces
{
    public interface IEscuelaService
    {
        Task AddEscuela(Escuela escuela);
        Task DeleteEscuela(int id);
        Task<IEnumerable<Escuela>> GetEscuelas();
        Task<Escuela> GetEscuela(int id);
        Task UpdateEscuela(Escuela escuela);
    }
}
