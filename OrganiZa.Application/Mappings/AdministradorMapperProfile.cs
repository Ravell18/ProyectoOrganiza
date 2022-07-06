using AutoMapper;
using OrganiZa.Domain.DTOs;
using OrganiZa.Domain.Entities;
using System;

namespace OrganiZa.Application.Mappings
{
    public class AdministradorMapperProfile:Profile
    {
        public int CreatedBy { get; set; }
        public AdministradorMapperProfile()
        {
            CreateMap<Administrador, AdministradorRequestDto>();
            CreateMap<Administrador, AdministradorResponseDto>();
            CreateMap<AdministradorRequestDto, Administrador>().AfterMap(
            ((source, destination) =>{
                destination.CreateAt = DateTime.Now;
                destination.CreatedBy = 3;
                destination.Status = true;
            }));
            CreateMap<AdministradorResponseDto, Administrador>();
        }
    }
}
