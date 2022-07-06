using OrganiZa.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrganiZa.Domain.Interfaces
{
    public interface IPagosService
    {
        Task AddPago(Pago pago);
        Task DeletePago(int id);
        Task<IEnumerable<Pago>> GetPagos();
        Task<Pago> GetPago(int id);
        Task UpdatePago(Pago pago);
    }
}
