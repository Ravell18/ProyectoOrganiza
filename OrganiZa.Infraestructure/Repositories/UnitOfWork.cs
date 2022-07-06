using OrganiZa.Domain.Interfaces;
using OrganiZa.Infraestructure.Data;
using OrganiZa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrganiZa.Infraestructure.Repositories
{

    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly OrganizarecContext _context;
        private readonly IRepository<User> _usuarioRepository;
        private readonly IRepository<Calendario> _calendarioRepository;
        private readonly IRepository<Escuela> _escuelaRepository;
        private readonly IRepository<Administrador> _administradorRepository;
        private readonly IRepository<Tutor> _tutorRepository;
        private readonly IRepository<Pago> _pagoRepository;



        public UnitOfWork(OrganizarecContext context)
        {
            this._context = context;
        }

        public IRepository<User> UsuarioRepository => _usuarioRepository ?? new SQLRepository<User>(_context);
        public IRepository<Calendario> CalendarioRepository => _calendarioRepository ?? new SQLRepository<Calendario>(_context);
        public IRepository<Escuela> EscuelaRepository => _escuelaRepository ?? new SQLRepository<Escuela>(_context);
        public IRepository<Tutor> TutorRepository => _tutorRepository ?? new SQLRepository<Tutor>(_context);
        public IRepository<Administrador> AdmministradorRepository => _administradorRepository ?? new SQLRepository<Administrador>(_context);

        public IRepository<Pago> PagoRepository => _pagoRepository ?? new SQLRepository<Pago>(_context);

        public void Dispose()
        {
            if (_context == null)
                _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
