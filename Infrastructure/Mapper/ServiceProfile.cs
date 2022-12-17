using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.Mapper;

public class ServiceProfile:Profile
{
    public ServiceProfile()
    {
        
        CreateMap<Course,GetCourse>().ReverseMap();
        CreateMap<AddEnrollment, Enrollment>().ReverseMap();
        CreateMap<Enrollment, GetEnrollment>().ReverseMap();
        CreateMap<AddStudent, Student>().ReverseMap()
       .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.FileName));
        CreateMap<Student, GetStudent>().ReverseMap();
        CreateMap<AddStudent, GetStudent>().ReverseMap();
    }
}