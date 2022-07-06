using OrganiZa.Domain.Entities;
using OrganiZa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrganiZa.Application.Services
{
    public class PagoService : IPagosService
    {
        public IUnitOfWork _unitOfWork;
        public PagoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddPago(Pago pago)
        {
            Expression < Func < Pago, bool>> expression = item => item.Id == pago.Id;
            var Pago = await _unitOfWork.PagoRepository.FindByCondition(expression);
            if (Pago.Any(item => item.Id == pago.Id))
                throw new Exception("Este pago ya ha sido registrado");
            await _unitOfWork.PagoRepository.Add(pago);
        }

        public async Task DeletePago(int id)
        {
            await _unitOfWork.PagoRepository.Delete(id);
        }

        public async Task<IEnumerable<Pago>> GetPagos()
        {
            return await _unitOfWork.PagoRepository.GetAll();
        }

        public async Task<Pago> GetPago(int id)
        {
            return await _unitOfWork.PagoRepository.GetById(id);
        }

        public async Task UpdatePago(Pago pago)
        {
            await _unitOfWork.PagoRepository.Update(pago);
        }
    }
}
