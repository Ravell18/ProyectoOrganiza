using OrganiZa.Domain.Entities;
using OrganiZa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrganiZa.Application.Services
{
    public class UsuarioService:IUsuarioService
    {
        public IUnitOfWork _unitOfWork;
        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddUsuario(User usuario)
        {
            Expression<Func<User, bool>> expression = item => item.Id == usuario.Id;
            var usuarios = await _unitOfWork.UsuarioRepository.FindByCondition(expression);
            if (usuarios.Any(item => item.Id == usuario.Id))
                throw new Exception("Este usuario ya ha sido registrado");
            await _unitOfWork.UsuarioRepository.Add(usuario);
        }

        public async Task DeleteUsuario(int id)
        {
            await _unitOfWork.UsuarioRepository.Delete(id);
        }

        public async Task<IEnumerable<User>> GetUsuarios()
        {
            return await _unitOfWork.UsuarioRepository.GetAll();
        }

        public async Task<User> GetUsuario(int id)
        {
            return await _unitOfWork.UsuarioRepository.GetById(id);
        }

        public async Task UpdateUsuario(User usuario)
        {
            await _unitOfWork.UsuarioRepository.Update(usuario);
        }
    }
}
