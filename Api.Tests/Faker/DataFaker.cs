using Api.Models;

namespace Faker;

public static class DataFaker
{
    public static List<EmployeeStatus> FakeEmployeeStatuses()
    {
        List<EmployeeStatus> statuses = [];
        for (int i = 1; i <= 10; i++)
        {
            statuses.Add(new()
            {
                EmployeeStatusId = i,
                Title = $"Status {i}"
            });
        }
        return statuses;
    }

    public static List<EmployeePosition> FakeEmployeePositions()
    {
        List<EmployeePosition> positions = [];
        for (int i = 1; i <= 10; i++)
        {
            positions.Add(new()
            {
                EmployeePositionId = i,
                Title = $"Position {i}"
            });
        }
        return positions;
    }

    public static List<Employee> FakeEmployees()
    {
        EmployeePosition fakePosition = new() { EmployeePositionId = 1, Title = "FAKE" };
        EmployeeStatus fakeStatus = new() { EmployeeStatusId = 1, Title = "Fake" };
        List<Employee> employees = [];
        for (int i = 1; i <= 10; i++)
        {
            employees.Add(
                new()
                {
                    EmployeeId = i,
                    Username = $"Username{i}",
                    Password = $"Password{i}",
                    Name = $"Name{i}",
                    DateHired = DateOnly.FromDateTime(DateTime.Now),
                    DateTerminated = DateOnly.FromDateTime(DateTime.Now),
                    EmployeeStatus = fakeStatus,
                    EmployeePosition = fakePosition
                }
            );
        }

        return employees;
    }

    public static List<Customer> FakeCustomers()
    {
        CustomerStatus fakeStatus = new() { CustomerStatusId = 1, Title = "Fake" };
        List<Customer> employees = [];
        for (int i = 1; i <= 10; i++)
        {
            employees.Add(
                new()
                {
                    CustomerId = i,
                    Username = $"Username{i}",
                    Password = $"Password{i}",
                    Name = $"Name{i}",
                    CustomerStatus = fakeStatus
                }
            );
        }

        return employees;
    }

    public static List<Effect> FakeEffects()
    {
        List<Effect> effects = [];
        for (int i = 1; i <= 10; i++)
        {
            effects.Add(new()
            {
                EffectId = i,
                Duration = i * 10,
                Description = $"Effect {i}"
            });
        }
        return effects;
    }

    public static List<OrderStatus> FakeOrderStatuses()
    {
        List<OrderStatus> effects = [];
        for (int i = 1; i <= 10; i++)
        {
            effects.Add(new()
            {
                OrderStatusId = i,
                Title = $"OrderS Status {i}"
            });
        }
        return effects;
    }

    public static List<CustomerStatus> FakeCustomerStatuses()
    {
        List<CustomerStatus> statuses = [];
        for (int i = 1; i <= 10; i++)
        {
            statuses.Add(new()
            {
                CustomerStatusId = i,
                Title = $"Status {i}"
            });
        }
        return statuses;
    }

    public static List<Ingredient> FakeIngredients()
    {
        Effect fakeEffect = new() { EffectId = 1, Description = "Fake", Duration = 60, Value = 40 };
        List<Ingredient> ingredients = [];
        for (int i = 1; i <= 10; i++)
        {
            ingredients.Add(
                new()
                {
                    IngredientId = i,
                    Name = $"Ingredient {i}",
                    Description = $"Ingredient {i}",
                    Price = i * 10,
                    Cost = i * 5,
                    CurrentStock = i,
                    Image = $"Image-{i}",
                    Effect = fakeEffect
                }
            );
        }

        return ingredients;
    }

    public static List<Potion> FakePotions()
    {
        Effect fakeEffect = new() { EffectId = 1, Description = "Fake", Duration = 60, Value = 40 };
        Effect fakeEffect2 = new() { EffectId = 2, Description = "Fake 2", Duration = 60, Value = 40 };
        List<Potion> potions = [];
        for (int i = 1; i <= 10; i++)
        {
            potions.Add(
                new()
                {
                    PotionId = i,
                    Name = $"Ingredient {i}",
                    Description = $"Ingredient {i}",
                    Price = i * 10,
                    Cost = i * 5,
                    CurrentStock = i,
                    Image = $"Image-{i}"
                }
            );
        }

        return potions;
    }
}
