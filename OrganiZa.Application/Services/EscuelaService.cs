using OrganiZa.Domain.Entities;
using OrganiZa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace OrganiZa.Application.Services
{
    public class EscuelaService:IEscuelaService
    {
        public IUnitOfWork _unitOfWork;
        public EscuelaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddEscuela(Escuela escuela)
        {
            Expression<Func<Escuela, bool>> expression = item => item.Id == escuela.Id;
            var escuelas = await _unitOfWork.EscuelaRepository.FindByCondition(expression);
            if (escuelas.Any(item => item.Id == escuela.Id))
                throw new Exception("Esta escuela ya ha sido registrada");
            await _unitOfWork.EscuelaRepository.Add(escuela);
        }

        public async Task DeleteEscuela(int id)
        {
            await _unitOfWork.EscuelaRepository.Delete(id);
        }

        public async Task<IEnumerable<Escuela>> GetEscuelas()
        {
            return await _unitOfWork.EscuelaRepository.GetAll();
        }

        public async Task<Escuela> GetEscuela(int id)
        {
            return await _unitOfWork.EscuelaRepository.GetById(id);
        }

        public async Task UpdateEscuela(Escuela escuela)
        {
            await _unitOfWork.EscuelaRepository.Update(escuela);
        }
    }
}
