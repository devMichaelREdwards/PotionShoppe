using Api.Models;
using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateCustomerMappings();
        CreateEmployeeMappings();
        CreateEffectMappings();
        CreateIngredientMappings();
        CreateOrderMappings();

        Map<Potion, PotionDto>();
        Map<PotionEffect, PotionEffectDto>();
        CreateMap<PotionEffectDto, string>().ConvertUsing(pe => pe.EffectDescription());
    }

    private void Map<T1, T2>()
    {
        CreateMap<T1, T2>().ReverseMap();
    }

    private void CreateCustomerMappings()
    {
        CreateMap<CustomerStatus, string>().ConvertUsing(p => p.Title);
        CreateMap<string, CustomerStatus>().ConvertUsing(p => null);
        Map<CustomerStatus, CustomerStatusDto>();
        Map<Customer, CustomerDto>();
    }

    private void CreateEmployeeMappings()
    {
        CreateMap<EmployeeStatus, string>().ConvertUsing(p => p.Title);
        CreateMap<string, EmployeeStatus>().ConvertUsing(p => null);
        CreateMap<EmployeePosition, string>().ConvertUsing(p => p.Title);
        CreateMap<string, EmployeePosition>().ConvertUsing(p => null);

        Map<EmployeeStatus, EmployeeStatusDto>();
        Map<EmployeePosition, EmployeePositionDto>();
        Map<Employee, EmployeeDto>();
        CreateMap<Employee, string>().ConstructUsing(e => e.Name);
    }

    private void CreateEffectMappings()
    {
        Map<Effect, EffectDto>();
        CreateMap<EffectDto, string>().ConvertUsing(e => e.BuildDescription());
        CreateMap<string, Effect>().ConstructUsing(e => null);
    }

    private void CreateIngredientMappings()
    {
        Map<Ingredient, IngredientDto>();
    }

    private void CreateOrderMappings()
    {
        Map<OrderStatus, OrderStatusDto>();
    }
}
