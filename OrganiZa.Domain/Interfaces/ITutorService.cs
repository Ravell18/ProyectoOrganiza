using OrganiZa.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrganiZa.Domain.Interfaces
{
    public interface ITutorService
    {
        Task AddTutor(Tutor tutor);
        Task DeleteTutor(int id);
        Task<IEnumerable<Tutor>> GetTutores();
        Task<Tutor> GetTutor(int id);
        Task UpdateTutor(Tutor tutor);
    }
}
