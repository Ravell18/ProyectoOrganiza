using AutoMapper;
using OrganiZa.Domain.DTOs;
using OrganiZa.Domain.Entities;
using System;

namespace OrganiZa.Application.Mappings
{
    public class UsuarioMapperProfile:Profile
    {
        public int CreatedBy { get; set; }
        public UsuarioMapperProfile()
        {
            CreateMap<User, UsuarioRequestDto>();
            CreateMap<User, UsuarioResponseDto>();
            CreateMap<UsuarioRequestDto, User>().AfterMap(
            ((source, destination) =>{
                destination.CreateAt = DateTime.Now;
                destination.CreatedBy = 3;
                destination.Status = true;
            }));
            CreateMap<UsuarioResponseDto, User>();
        }
    }
}
