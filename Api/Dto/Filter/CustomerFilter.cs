using Api.Classes;

namespace Api.Models;

public partial class CustomerFilter : IFilter<Customer>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? CustomerStatus { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }

    public dynamic? GetValue(string key)
    {
        return key switch
        {
            "firstName" => FirstName,
            "lastName" => LastName,
            "status" => CustomerStatus,
            "userName" => UserName,
            "email" => Email,
            _ => null,
        };
    }

    public static CustomerFilter? BuildFilter(IQueryCollection query)
    {
        if (query.Count == 0) return null;

        return new()
        {
            FirstName = ParseFilter.GetString("firstName", query),
            LastName = ParseFilter.GetString("lastName", query),
            UserName = ParseFilter.GetString("userName", query),
            Email = ParseFilter.GetString("email", query),
            CustomerStatus = ParseFilter.GetInt("status", query),
        };
    }
}
