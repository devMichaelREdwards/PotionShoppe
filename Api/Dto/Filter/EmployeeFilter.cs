using Api.Classes;

namespace Api.Models;

public partial class EmployeeFilter : IFilter<Employee>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? EmployeeStatus { get; set; }
    public List<int>? EmployeePositions { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }

    public dynamic? GetValue(string key)
    {
        return key switch
        {
            "firstName" => FirstName,
            "lastName" => LastName,
            "status" => EmployeeStatus,
            "positions" => EmployeePositions,
            "userName" => UserName,
            "email" => Email,
            _ => null,
        };
    }

    public static EmployeeFilter? BuildFilter(IQueryCollection query)
    {
        if (query.Count == 0) return null;

        return new()
        {
            FirstName = ParseFilter.GetString("firstName", query),
            LastName = ParseFilter.GetString("lastName", query),
            UserName = ParseFilter.GetString("userName", query),
            Email = ParseFilter.GetString("email", query),
            EmployeeStatus = ParseFilter.GetInt("status", query),
            EmployeePositions = ParseFilter.GetNumberOptions("positions", query),
        };
    }
}
