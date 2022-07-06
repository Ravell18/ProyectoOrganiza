using OrganiZa.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace OrganiZa.Domain.Interfaces
{
    public interface ICalendarioServicio
    {
        Task AddCalendario(Calendario calendario);
        Task DeleteCalendario(int id);
        Task<IEnumerable<Calendario>> GetCalendarios();
        Task<Calendario> GetCalendario(int id);
        Task UpdateCalendario(Calendario calendario);
    }
}
