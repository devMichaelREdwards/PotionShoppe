using Api.Models;
using AutoMapper;

namespace Setup;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateCustomerMappings();
        CreateEmployeeMappings();
        CreateEffectMappings();
        CreateIngredientMappings();
        CreatePotionMappings();
        CreateOrderMappings();
        CreateReceiptMappings();
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
        CreateMap<Customer, string>().ConvertUsing(c => c.Name);
    }

    private void CreateEmployeeMappings()
    {
        CreateMap<EmployeeStatus, string>().ConvertUsing(p => p.Title);
        CreateMap<string, EmployeeStatus>().ConvertUsing(p => null);
        CreateMap<EmployeePosition, string>().ConvertUsing(p => p.Title);
        CreateMap<string, EmployeePosition>().ConvertUsing(p => null);

        Map<EmployeeStatus, EmployeeStatusDto>();
        Map<EmployeePosition, EmployeePositionDto>();
        CreateMap<Employee, string>().ConstructUsing(e => e.Name);
        Map<Employee, EmployeeDto>();
    }

    private void CreateEffectMappings()
    {
        Map<Effect, EffectDto>();
        CreateMap<Effect, string>().ConvertUsing(e => EffectDto.BuildDescription(e));
        CreateMap<EffectDto, string>().ConvertUsing(e => e.BuildDescription());
        CreateMap<string, Effect>().ConstructUsing(e => null);
    }

    private void CreatePotionMappings()
    {
        Map<Potion, PotionDto>();
        CreateMap<Potion, string>().ConvertUsing(p => p.Name);
        CreateMap<PotionDto, string>().ConvertUsing(p => p.Name);
        Map<PotionEffect, PotionEffectDto>();
        CreateMap<PotionEffectDto, string>().ConvertUsing(pe => pe.Effect);
    }

    private void CreateIngredientMappings()
    {
        Map<Ingredient, IngredientDto>();
    }

    private void CreateOrderMappings()
    {
        Map<OrderStatus, OrderStatusDto>();
        Map<Order, OrderDto>();
        Map<OrderPotion, OrderPotionDto>();
        Map<OrderIngredient, OrderIngredientDto>();
        CreateMap<Order, string>().ConvertUsing(o => o.OrderNumber);
        CreateMap<OrderDto, string>().ConvertUsing(o => o.OrderNumber);
    }

    private void CreateReceiptMappings()
    {
        Map<Receipt, ReceiptDto>();
    }
}
