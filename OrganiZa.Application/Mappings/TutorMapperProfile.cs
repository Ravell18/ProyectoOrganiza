using AutoMapper;
using OrganiZa.Domain.DTOs;
using OrganiZa.Domain.Entities;
using System;

namespace OrganiZa.Application.Mappings
{
    public class TutorMapperProfile:Profile
    {
        public int CreatedBy { get; set; }
        public TutorMapperProfile()
        {
            CreateMap<Tutor, TutorRequestDto>();
            CreateMap<Tutor, TutorResponseDto>();
            CreateMap<TutorRequestDto, Tutor>().AfterMap(
            ((source, destination) =>{
                destination.CreateAt = DateTime.Now;
                destination.CreatedBy = 3;
                destination.Status = true;
            }));
            CreateMap<TutorResponseDto, Tutor>();
        }
    }
}
