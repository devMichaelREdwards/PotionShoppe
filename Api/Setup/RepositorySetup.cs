using Api.Data;
using Api.Models;

namespace Setup;

public static class RepositorySetup
{
    public static void Setup(IServiceCollection services)
    {
        services.AddScoped<IRepository<EmployeeStatus>, EmployeeStatusRepository>();
        services.AddScoped<IRepository<EmployeePosition>, EmployeePositionRepository>();
        services.AddScoped<IRepository<Employee>, EmployeeRepository>();
        services.AddScoped<IRepository<Effect>, EffectRepository>();
        services.AddScoped<IRepository<OrderStatus>, OrderStatusRepository>();
        services.AddScoped<IRepository<CustomerStatus>, CustomerStatusRepository>();
        services.AddScoped<IRepository<Customer>, CustomerRepository>();
        services.AddScoped<IRepository<Ingredient>, IngredientRepository>();
        services.AddScoped<IRepository<Potion>, PotionRepository>();
        services.AddScoped<IRepository<Order>, OrderRepository>();
        services.AddScoped<IRepository<Receipt>, ReceiptRepository>();
        services.AddScoped<IRepository<PotionEffect>, PotionEffectRepository>();
        services.AddScoped<IRepository<OrderIngredient>, OrderIngredientRepository>();
    }
}
