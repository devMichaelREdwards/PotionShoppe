using Api.Models;
using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeDto>();
        CreateMap<EmployeePosition, string>().ConvertUsing(p => p.Title);
        CreateMap<EmployeeStatus, string>().ConvertUsing(p => p.Title);
        CreateMap<EmployeeStatus, EmployeeStatusDto>();
        CreateMap<EmployeeStatusDto, EmployeeStatus>();
        CreateMap<EmployeePosition, EmployeePositionDto>();
        CreateMap<EmployeePositionDto, EmployeePosition>();
        CreateMap<Effect, EffectDto>();
        CreateMap<EffectDto, Effect>();
    }
}
