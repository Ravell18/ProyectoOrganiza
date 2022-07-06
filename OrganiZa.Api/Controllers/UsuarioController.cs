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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            this._usuarioService = usuarioService;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioService.GetUsuarios();
            var usuariosDto = _mapper.Map<IEnumerable<User>, IEnumerable<UsuarioResponseDto>>(usuarios);
            var response = new ApiResponse<IEnumerable<UsuarioResponseDto>>(usuariosDto);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _usuarioService.GetUsuario(id);
            var usuarioDto = _mapper.Map<User, UsuarioResponseDto>(usuario);
            var response = new ApiResponse<UsuarioResponseDto>(usuarioDto);

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(UsuarioRequestDto usuariolDto)
        {
            var usuario = _mapper.Map<UsuarioRequestDto, User>(usuariolDto);
            await _usuarioService.AddUsuario(usuario);
            var usuarioresponseDto = _mapper.Map<User, UsuarioResponseDto>(usuario);
            var response = new ApiResponse<UsuarioResponseDto>(usuarioresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _usuarioService.DeleteUsuario(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, UsuarioResponseDto usuarioResponse)
        {
            var usuario = _mapper.Map<User>(usuarioResponse);
            usuario.Id = id;
            usuario.UpdateAt = DateTime.Now;
            usuario.UpdatedBy = 1;
            await _usuarioService.UpdateUsuario(usuario);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
