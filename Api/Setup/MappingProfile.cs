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
        Map<Customer, CustomerDto>();
        CreateMap<CustomerStatus, string>().ConvertUsing(p => p.Title);
        CreateMap<string, CustomerStatus>().ConvertUsing(p => null);
        Map<CustomerStatus, CustomerStatusDto>();
        Map<Customer, CustomerDto>();
        CreateMap<Customer, string>().ConvertUsing(c => $"{c.FirstName} {c.LastName}");
        CreateMap<Customer, CustomerListing>()
            .ConvertUsing(
                e =>
                    new()
                    {
                        CustomerId = e.CustomerId,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        CustomerStatus = e.CustomerStatus.Title,
                        UserName = e.CustomerAccounts.First().UserName,
                        Email = e.CustomerAccounts.First().Email
                    }
            );
    }

    private void CreateEmployeeMappings()
    {
        CreateMap<EmployeeStatus, string>().ConvertUsing(p => p.Title);
        CreateMap<string, EmployeeStatus>().ConvertUsing(p => null);
        CreateMap<EmployeePosition, string>().ConvertUsing(p => p.Title);
        CreateMap<string, EmployeePosition>().ConvertUsing(p => null);

        Map<EmployeeStatus, EmployeeStatusDto>();
        Map<EmployeePosition, EmployeePositionDto>();
        CreateMap<Employee, string>().ConstructUsing(e => $"{e.FirstName} {e.LastName}");
        Map<Employee, EmployeeDto>();
        CreateMap<Employee, EmployeeListing>()
            .ConvertUsing(
                e =>
                    new()
                    {
                        EmployeeId = e.EmployeeId,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        EmployeePosition = e.EmployeePosition.Title,
                        EmployeeStatus = e.EmployeeStatus.Title,
                        UserName = e.EmployeeAccounts.First().UserName
                    }
            );
    }

    private void CreateEffectMappings()
    {
        Map<Effect, EffectDto>();
        CreateMap<Effect, string>().ConvertUsing(e => EffectDto.BuildDescription(e));
        CreateMap<EffectDto, string>().ConvertUsing(e => e.BuildDescription());
        CreateMap<string, Effect>().ConstructUsing(e => null);
        CreateMap<Effect, EffectListing>()
            .ConvertUsing(
                e =>
                    new()
                    {
                        EffectId = e.EffectId,
                        Name = e.Name,
                        Value = e.Value,
                        Duration = e.Duration,
                        Description = EffectDto.BuildDescription(e),
                        Color = EffectListing.BuildEffectColor(e)
                    }
            );
    }

    private void CreatePotionMappings()
    {
        Map<Potion, PotionDto>();
        CreateMap<Potion, string>().ConvertUsing(p => p.Name);
        CreateMap<PotionDto, string>().ConvertUsing(p => p.Name);
        Map<PotionEffect, PotionEffectDto>();
        CreateMap<PotionEffectDto, string>().ConvertUsing(pe => pe.Effect);
        CreateMap<Potion, PotionListing>()
            .ConvertUsing(
                p =>
                    new()
                    {
                        PotionId = p.PotionId,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Products.First().Price,
                        Cost = p.Products.First().Cost,
                        CurrentStock = p.Products.First().CurrentStock,
                        Image = p.Image,
                        Active = p.Products.First().Active,
                        PotionEffects = PotionListing.BuildEffectsList(p)
                    }
            );
    }

    private void CreateIngredientMappings()
    {
        Map<Ingredient, IngredientDto>();
        Map<IngredientCategory, IngredientCategoryDto>();
        CreateMap<IngredientCategoryDto, string>().ConvertUsing(c => c.Title);
        CreateMap<Ingredient, IngredientListing>()
            .ConvertUsing(
                i =>
                    new()
                    {
                        IngredientId = i.IngredientId,
                        Name = i.Name,
                        Description = i.Description,
                        Price = i.Products.First().Price,
                        Cost = i.Products.First().Cost,
                        CurrentStock = i.Products.First().CurrentStock,
                        Image = i.Image,
                        Effect = IngredientListing.BuildIngredientEffect(i),
                        IngredientCategory = i.IngredientCategory.Title
                    }
            );
    }

    private void CreateOrderMappings()
    {
        Map<OrderStatus, OrderStatusDto>();
        Map<Order, OrderDto>();
        Map<OrderPotion, OrderPotionDto>();
        Map<OrderIngredient, OrderIngredientDto>();
        CreateMap<Order, string>().ConvertUsing(o => o.OrderNumber);
        CreateMap<OrderDto, string>().ConvertUsing(o => o.OrderNumber);
        CreateMap<Order, OrderListing>()
            .ConvertUsing(
                o =>
                    new()
                    {
                        OrderId = o.OrderId,
                        OrderNumber = o.OrderNumber,
                        Total = o.Total,
                        DatePlaced = o.DatePlaced,
                        Customer = $"{o.Customer.FirstName} {o.Customer.LastName}",
                        OrderStatus = o.OrderStatus.Title
                    }
            );
    }

    private void CreateReceiptMappings()
    {
        Map<Receipt, ReceiptDto>();
        CreateMap<Receipt, ReceiptListing>()
            .ConvertUsing(
                r =>
                    new()
                    {
                        ReceiptId = r.ReceiptId,
                        ReceiptNumber = r.ReceiptNumber,
                        Order = r.Order.OrderNumber,
                        DateFulfilled = r.DateFulfilled,
                        Employee = $"{r.Employee.FirstName} {r.Employee.LastName}",
                        Customer = $"{r.Order.Customer.FirstName} {r.Order.Customer.LastName}",
                        Total = r.Order.Total
                    }
            );
    }
}
