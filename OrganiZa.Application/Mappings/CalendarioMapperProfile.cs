using AutoMapper;
using OrganiZa.Domain.DTOs;
using OrganiZa.Domain.Entities;
using System;

namespace OrganiZa.Application.Mappings
{
    public class CalendarioMapperProfile:Profile
    {
        public int CreatedBy { get; set; }
        public CalendarioMapperProfile()
        {
            CreateMap<Calendario, CalendarioRequestDto>();
            CreateMap<Calendario, CalendarioReponseDto>();
            CreateMap<CalendarioRequestDto, Calendario>().AfterMap(
            ((source, destination) =>{
                destination.CreateAt = DateTime.Now;
                destination.CreatedBy = 3;
                destination.Status = true;
            }));
            CreateMap<CalendarioReponseDto, Calendario>();
        }
    }
}
