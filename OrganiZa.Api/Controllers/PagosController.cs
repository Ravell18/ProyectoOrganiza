using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganiZa.Domain.Interfaces;
using OrganiZa.Api.Responses;
using OrganiZa.Domain.Entities;
using OrganiZa.Domain.DTOs;

namespace OrganiZa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IPagosService _PagoService;
        private readonly IMapper _mapper;
        public PagoController(IPagosService pagoService, IMapper mapper)
        {
            this._PagoService = pagoService;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pago = await _PagoService.GetPagos();
            var pagoDto = _mapper.Map<IEnumerable<Pago>, IEnumerable<PagoResponseDto>>(pago);
            var response = new ApiResponse<IEnumerable<PagoResponseDto>>(pagoDto);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var pago = await _PagoService.GetPago(id);
            var pagoDto = _mapper.Map<Pago, PagoResponseDto>(pago);
            var response = new ApiResponse<PagoResponseDto>(pagoDto);

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(PagoRequestDto PagoDto)
        {
            var pago = _mapper.Map<PagoRequestDto, Pago>(PagoDto);
            await _PagoService.AddPago(pago);
            var pagoresponseDto = _mapper.Map<Pago, PagoResponseDto>(pago);
            var response = new ApiResponse<PagoResponseDto>(pagoresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _PagoService.DeletePago(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, PagoResponseDto PagoResponse)
        {
            var pago = _mapper.Map<Pago>(PagoResponse);
            pago.Id = id;
            pago.UpdateAt = DateTime.Now;
            pago.UpdatedBy = 1;
            await _PagoService.UpdatePago(pago);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
