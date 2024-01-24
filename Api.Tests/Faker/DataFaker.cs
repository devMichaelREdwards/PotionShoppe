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
}
