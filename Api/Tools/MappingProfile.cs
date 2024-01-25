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
    }

    private void CreateEffectMappings()
    {
        Map<Effect, EffectDto>();
        CreateMap<Effect, string>()
            .ConvertUsing(e => $"{e.Description} Do something here later? Should be in DTO");
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
