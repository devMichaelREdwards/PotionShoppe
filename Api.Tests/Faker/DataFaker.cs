using Api.Models;

namespace Faker;

public static class DataFaker
{
    public static List<EmployeeStatus> FakeEmployeeStatuses()
    {
        List<EmployeeStatus> statuses = [];
                for (int i = 1; i <= 10; i++)
        {
            statuses.Add(new () {
                EmployeeStatusId = i,
                Title = $"Status {i}"
            });
        }
        return statuses;
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
}
