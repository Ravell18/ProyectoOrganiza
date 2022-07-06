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
using OrganiZa.Infraestructure.Repositories;

namespace OrganiZa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorService _administradorService;
        private readonly IMapper _mapper;
        public AdministradorController(IAdministradorService administradorService, IMapper mapper)
        {
            this._administradorService = administradorService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var administradores = await _administradorService.GetAdministradores();
            var administradoresDto = _mapper.Map<IEnumerable<Administrador>, IEnumerable<AdministradorResponseDto>>(administradores);
            var response = new ApiResponse<IEnumerable<AdministradorResponseDto>>(administradoresDto);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var administrador = await _administradorService.GetAdministrador(id);
            var administradorDto = _mapper.Map<Administrador, AdministradorResponseDto>(administrador);
            var response = new ApiResponse<AdministradorResponseDto>(administradorDto);

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(AdministradorRequestDto administradorDto)
        {
            var admin = _mapper.Map<AdministradorRequestDto, Administrador>(administradorDto);
            await _administradorService.AddAdministrador(admin);
            var administradorresponseDto = _mapper.Map<Administrador, AdministradorResponseDto>(admin);
            var response = new ApiResponse<AdministradorResponseDto>(administradorresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _administradorService.DeleteAdministrador(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, AdministradorResponseDto administradorResponse)
        {
            var admin = _mapper.Map<Administrador>(administradorResponse);
            admin.Id = id;
            admin.UpdateAt = DateTime.Now;
            admin.UpdatedBy = 1;
            await _administradorService.UpdateAdministrador(admin);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
