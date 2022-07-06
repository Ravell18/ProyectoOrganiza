using OrganiZa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrganiZa.Domain.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {

        public IRepository<User> UsuarioRepository { get; }
        public IRepository<Calendario> CalendarioRepository { get; }
        public IRepository<Escuela> EscuelaRepository { get; }
        public IRepository<Administrador> AdmministradorRepository { get; }
        public IRepository<Tutor> TutorRepository { get; }
        public IRepository<Pago> PagoRepository { get; }


        void SaveChanges();
        Task SaveChangesAsync();
    }
}
