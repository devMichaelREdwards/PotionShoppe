using Api.Data;
using Api.Models;

namespace Setup;

public static class RepositorySetup
{
    public static void Setup(IServiceCollection services)
    {
        services.AddScoped<IRepository<EmployeeStatus>, EmployeeStatusRepository>();
        services.AddScoped<IRepository<EmployeePosition>, EmployeePositionRepository>();
        services.AddScoped<IListingRepository<Employee>, EmployeeRepository>();
        services.AddScoped<IListingRepository<Effect>, EffectRepository>();
        services.AddScoped<IRepository<OrderStatus>, OrderStatusRepository>();
        services.AddScoped<IListingRepository<Customer>, CustomerRepository>();
        services.AddScoped<IRepository<CustomerStatus>, CustomerStatusRepository>();
        services.AddScoped<IListingRepository<Ingredient>, IngredientRepository>();
        services.AddScoped<IListingRepository<Potion>, PotionRepository>();
        services.AddScoped<IListingRepository<Order>, OrderRepository>();
        services.AddScoped<IListingRepository<Receipt>, ReceiptRepository>();
        services.AddScoped<IRepository<PotionEffect>, PotionEffectRepository>();
        services.AddScoped<IRepository<CustomerAccount>, CustomerAccountRepository>();
        services.AddScoped<IRepository<EmployeeAccount>, EmployeeAccountRepository>();
        services.AddScoped<IRepository<IngredientCategory>, IngredientCategoryRepository>();
        services.AddScoped<IRepository<Product>, ProductRepository>();
    }
}
