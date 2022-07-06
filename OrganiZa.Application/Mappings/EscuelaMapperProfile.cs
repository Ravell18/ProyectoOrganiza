using AutoMapper;
using OrganiZa.Domain.DTOs;
using OrganiZa.Domain.Entities;
using System;

namespace OrganiZa.Application.Mappings
{
    public class EscuelaMapperProfile:Profile
    {
        public int CreatedBy { get; set; }
        public EscuelaMapperProfile()
        {
            CreateMap<Escuela, EscuelaRequestDto>();
            CreateMap<Escuela, EscuelaResponseDto>();
            CreateMap<EscuelaRequestDto, Escuela>().AfterMap(
            ((source, destination) =>{
                destination.CreateAt = DateTime.Now;
                destination.CreatedBy = 3;
                destination.Status = true;
            }));
            CreateMap<EscuelaResponseDto, Escuela>();
        }
    }
}
