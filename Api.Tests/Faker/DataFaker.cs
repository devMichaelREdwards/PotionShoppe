using Api.Models;

namespace Faker;

public static class DataFaker
{
    public static List<Employee> FakeEmployees()
    {
        EmployeePosition fakePosition = new EmployeePosition()
        {
            EmployeePositionId = 1,
            Title = "FAKE"
        };
        EmployeeStatus fakeStatus = new EmployeeStatus()
        {
            EmployeeStatusId = 1,
            Title = "Fake"
        };
        List<Employee> employees = new List<Employee>();
        for (int i = 1; i <= 10; i++)
        {
            employees.Add(new()
            {
                EmployeeId = i,
                Username = $"Username{i}",
                Password = $"Password{i}",
                Name = $"Name{i}",
                DateHired = DateOnly.FromDateTime(DateTime.Now),
                DateTerminated = DateOnly.FromDateTime(DateTime.Now),
                EmployeeStatus = fakeStatus,
                EmployeePosition = fakePosition
            });
        }

        return employees;
    }
}
