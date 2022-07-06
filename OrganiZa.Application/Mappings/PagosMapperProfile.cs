using AutoMapper;
using OrganiZa.Domain.DTOs;
using OrganiZa.Domain.Entities;
using System;

namespace OrganiZa.Application.Mappings
{
    public class PagoMapperProfile : Profile
    {
        public int CreatedBy { get; set; }
        public PagoMapperProfile()
        {
            CreateMap<Pago, PagoRequestDto>();
            CreateMap<Pago, PagoResponseDto>();
            CreateMap<PagoRequestDto, Pago>().AfterMap(
            ((source, destination) => {
                destination.CreateAt = DateTime.Now;
                destination.CreatedBy = 3;
                destination.Status = true;
            }));
            CreateMap<PagoResponseDto, Pago>();
        }
    }
}
