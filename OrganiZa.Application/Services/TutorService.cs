using OrganiZa.Domain.Entities;
using OrganiZa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrganiZa.Application.Services
{
    public class TutorService:ITutorService
    {
        public IUnitOfWork _unitOfWork;
        public TutorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddTutor(Tutor tutor)
        {
            Expression<Func<Tutor, bool>> expression = item => item.Id == tutor.Id;
            var tutores = await _unitOfWork.TutorRepository.FindByCondition(expression);
            if (tutores.Any(item => item.Id == tutor.Id))
                throw new Exception("Este tutor ya ha sido registrado");
            await _unitOfWork.TutorRepository.Add(tutor);
        }

        public async Task DeleteTutor(int id)
        {
            await _unitOfWork.TutorRepository.Delete(id);
        }

        public async Task<IEnumerable<Tutor>> GetTutores()
        {
            return await _unitOfWork.TutorRepository.GetAll();
        }

        public async Task<Tutor> GetTutor(int id)
        {
            return await _unitOfWork.TutorRepository.GetById(id);
        }

        public async Task UpdateTutor(Tutor tutor)
        {
            await _unitOfWork.TutorRepository.Update(tutor);
        }
    }
}
