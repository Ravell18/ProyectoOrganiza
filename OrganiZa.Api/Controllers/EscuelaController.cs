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
    public class EscuelaController : ControllerBase
    {
        private readonly IEscuelaService _escuelaService;
        private readonly IMapper _mapper;
        public EscuelaController(IEscuelaService escuelaService, IMapper mapper)
        {
            this._escuelaService = escuelaService;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var escuelas = await _escuelaService.GetEscuelas();
            var escuelasDto = _mapper.Map<IEnumerable<Escuela>, IEnumerable<EscuelaResponseDto>>(escuelas);
            var response = new ApiResponse<IEnumerable<EscuelaResponseDto>>(escuelasDto);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var escuela = await _escuelaService.GetEscuela(id);
            var escuelaDto = _mapper.Map<Escuela, EscuelaResponseDto>(escuela);
            var response = new ApiResponse<EscuelaResponseDto>(escuelaDto);

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(EscuelaRequestDto escuelaDto)
        {
            var escuela = _mapper.Map<EscuelaRequestDto, Escuela>(escuelaDto);
            await _escuelaService.AddEscuela(escuela);
            var escuelaresponseDto = _mapper.Map<Escuela, EscuelaResponseDto>(escuela);
            var response = new ApiResponse<EscuelaResponseDto>(escuelaresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _escuelaService.DeleteEscuela(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, EscuelaResponseDto escuelaResponse)
        {
            var escuela = _mapper.Map<Escuela>(escuelaResponse);
            escuela.Id = id;
            escuela.UpdateAt = DateTime.Now;
            escuela.UpdatedBy = 1;
            await _escuelaService.UpdateEscuela(escuela);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
