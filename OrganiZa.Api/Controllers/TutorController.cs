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
    public class TutorController : ControllerBase
    {
        private readonly ITutorService _tutorService;
        private readonly IMapper _mapper;
        public TutorController(ITutorService tutorService, IMapper mapper)
        {
            this._tutorService = tutorService;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tutores = await _tutorService.GetTutores();
            var tutoresDto = _mapper.Map<IEnumerable<Tutor>, IEnumerable<TutorResponseDto>>(tutores);
            var response = new ApiResponse<IEnumerable<TutorResponseDto>>(tutoresDto);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var tutor = await _tutorService.GetTutor(id);
            var tutorDto = _mapper.Map<Tutor,TutorResponseDto>(tutor);
            var response = new ApiResponse<TutorResponseDto>(tutorDto);

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(TutorRequestDto tutorDto)
        {
            var tutor = _mapper.Map<TutorRequestDto, Tutor>(tutorDto);
            await _tutorService.AddTutor(tutor);
            var tutorresponseDto = _mapper.Map<Tutor, TutorResponseDto>(tutor);
            var response = new ApiResponse<TutorResponseDto>(tutorresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _tutorService.DeleteTutor(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, TutorResponseDto tutorResponse)
        {
            var tutor = _mapper.Map<Tutor>(tutorResponse);
            tutor.Id = id;
            tutor.UpdateAt = DateTime.Now;
            tutor.UpdatedBy = 1;
            await _tutorService.UpdateTutor(tutor);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
