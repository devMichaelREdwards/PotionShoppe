using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class DataContext : DbContext
{
    public DbSet<Employee> Employee { get; set; }
    public DbSet<EmployeePosition> EmployeePosition { get; set; }
    public DbSet<EmployeeStatus> EmployeeStatus { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
}
