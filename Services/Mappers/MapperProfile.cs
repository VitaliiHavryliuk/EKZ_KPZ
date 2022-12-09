using AutoMapper;
using DTOs.ProjectTasksDTOs;
using Domain.Entities;
using Domain.Enums;

namespace Services.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateProjectTaskDTO, ProjectTask>()
                .ForMember(e => e.Status, g => g.MapFrom(dto => 
                dto.Status == Status.ToDo.ToString() ? Status.ToDo 
                : dto.Status == Status.OnReview.ToString() ? Status.OnReview
                : dto.Status == Status.InProgress.ToString() ? Status.InProgress 
                : dto.Status == Status.Done.ToString() ? Status.Done : Status.ToDo));

            CreateMap<ProjectTask, ProjectTaskDTO>()
                .ForMember(dto => dto.Status, g => g.MapFrom(e => e.Status.ToString()));
        }
    }
}
