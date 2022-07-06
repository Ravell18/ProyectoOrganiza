using OrganiZa.Domain.Entities;
using OrganiZa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrganiZa.Application.Services
{
    public class CalendarioService:ICalendarioServicio
    {
        public IUnitOfWork _unitOfWork;
        public CalendarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddCalendario(Calendario calendario)
        {
            Expression<Func<Calendario, bool>> expression = item => item.Id == calendario.Id;
            var calendarios = await _unitOfWork.CalendarioRepository.FindByCondition(expression);
            if (calendarios.Any(item => item.Id == calendario.Id))
                throw new Exception("Este calendario ya ha sido registrado");
            await _unitOfWork.CalendarioRepository.Add(calendario);
        }

        public async Task DeleteCalendario(int id)
        {
            await _unitOfWork.CalendarioRepository.Delete(id);
        }

        public async Task<IEnumerable<Calendario>> GetCalendarios()
        {
            return await _unitOfWork.CalendarioRepository.GetAll();
        }

        public async Task<Calendario> GetCalendario(int id)
        {
            return await _unitOfWork.CalendarioRepository.GetById(id);
        }

        public async Task UpdateCalendario(Calendario calendario)
        {
            await _unitOfWork.CalendarioRepository.Update(calendario);
        }
    }
}
