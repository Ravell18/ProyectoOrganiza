using OrganiZa.Domain.Entities;
using OrganiZa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrganiZa.Application.Services
{
    public class AdministradorService:IAdministradorService
    {
        public IUnitOfWork _unitOfWork;
        public AdministradorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAdministrador(Administrador administrador)
        {
            Expression<Func<Administrador, bool>> expression = item => item.Id == administrador.Id;
            var administradores = await _unitOfWork.AdmministradorRepository.FindByCondition(expression);
            if (administradores.Any(item => item.Id == administrador.Id))
                throw new Exception("Este administrador ya ha sido registrado");
            await _unitOfWork.AdmministradorRepository.Add(administrador);
        }

        public async Task DeleteAdministrador(int id)
        {
            await _unitOfWork.AdmministradorRepository.Delete(id);
        }

        public async Task<IEnumerable<Administrador>> GetAdministradores()
        {
            return await _unitOfWork.AdmministradorRepository.GetAll();
        }

        public async Task<Administrador> GetAdministrador(int id)
        {
            return await _unitOfWork.AdmministradorRepository.GetById(id);
        }

        public async Task UpdateAdministrador(Administrador administrador)
        {
            await _unitOfWork.AdmministradorRepository.Update(administrador);
        }
    }
}
