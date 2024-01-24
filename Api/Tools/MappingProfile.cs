using Api.Models;
using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EmployeePosition, string>().ConvertUsing(p => p.Title);
        CreateMap<EmployeeStatus, string>().ConvertUsing(p => p.Title);

        Map<Employee, EmployeeDto>();
        Map<EmployeeStatus, EmployeeStatusDto>();
        Map<EmployeePosition, EmployeePositionDto>();
        Map<Effect, EffectDto>();
        Map<OrderStatus, OrderStatusDto>();
    }

    private void Map<T1, T2>()
    {
        CreateMap<T1, T2>().ReverseMap();
    }
}
