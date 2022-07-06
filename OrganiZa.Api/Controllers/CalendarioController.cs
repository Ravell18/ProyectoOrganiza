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
    public class CalendarioController : ControllerBase
    {
        private readonly ICalendarioServicio _calendarioService;
        private readonly IMapper _mapper;
        public CalendarioController(ICalendarioServicio calendarioService, IMapper mapper)
        {
            this._calendarioService = calendarioService;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var calendarios = await _calendarioService.GetCalendarios();
            var calendariosDto = _mapper.Map<IEnumerable<Calendario>, IEnumerable<CalendarioReponseDto>>(calendarios);
            var response = new ApiResponse<IEnumerable<CalendarioReponseDto>>(calendariosDto);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var calendario = await _calendarioService.GetCalendario(id);
            var calendarioDto = _mapper.Map<Calendario, CalendarioReponseDto>(calendario);
            var response = new ApiResponse<CalendarioReponseDto>(calendarioDto);

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CalendarioRequestDto calendarioDto)
        {
            var calendario = _mapper.Map<CalendarioRequestDto, Calendario>(calendarioDto);
            await _calendarioService.AddCalendario(calendario);
            var calendarioresponseDto = _mapper.Map<Calendario, CalendarioReponseDto>(calendario);
            var response = new ApiResponse<CalendarioReponseDto>(calendarioresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _calendarioService.DeleteCalendario(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, CalendarioReponseDto calendarioReponse)
        {
            var calendario = _mapper.Map<Calendario>(calendarioReponse);
            calendario.Id = id;
            calendario.UpdateAt = DateTime.Now;
            calendario.UpdatedBy = 1;
            await _calendarioService.UpdateCalendario(calendario);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
