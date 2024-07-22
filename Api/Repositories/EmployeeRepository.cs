using Api.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace Api.Data;

public class EmployeeRepository : IListingRepository<Employee>, IDisposable
{
    private PotionShoppeContext _context;

    public EmployeeRepository(PotionShoppeContext context)
    {
        _context = context;
    }

    public IEnumerable<Employee> Get()
    {
        var employees = _context.Employees
    .Include(e => e.EmployeeStatus)
    .Include(e => e.EmployeePosition)
    .Include(e => e.EmployeeAccounts)
    .AsQueryable();
        return [.. employees];
    }

    public IEnumerable<Employee> GetListing(IFilter<Employee>? filter = null, Pagination? page = null, SortOrder? sortOrder = null)
    {
        var employees = _context.Employees
            .Include(e => e.EmployeeStatus)
            .Include(e => e.EmployeePosition)
            .Include(e => e.EmployeeAccounts)
            .AsQueryable();
        string? firstName = filter?.GetValue("firstName");
        if (firstName != null)
        {
            employees = employees.Where(e => e.FirstName!.ToLower().Contains(firstName.ToLower()));
        }

        string? lastName = filter?.GetValue("lastName");
        if (lastName != null)
        {
            employees = employees.Where(e => e.LastName!.ToLower().Contains(lastName.ToLower()));
        }

        string? userName = filter?.GetValue("userName");
        if (userName != null)
        {
            employees = employees.Where(e => e.EmployeeAccounts.First().UserName!.ToLower().Contains(userName.ToLower()));
        }

        string? email = filter?.GetValue("email");
        if (email != null)
        {
            employees = employees.Where(e => e.EmployeeAccounts.First().Email!.ToLower().Contains(email.ToLower()));
        }

        List<int>? positions = filter?.GetValue("positions");
        if (positions != null)
        {
            employees = employees.Where(e => positions.Contains(e.EmployeePositionId ?? 0));
        }

        int? status = filter?.GetValue("status");
        if (status != null)
        {
            employees = employees.Where(e => e.EmployeeStatusId == status);
        }
        return employees.ToPagedList(page?.Page ?? 1, page?.Limit ?? 20);
    }

    public Employee? GetById(int id)
    {
        return _context.Employees.Find(id);
    }

    public EmployeePosition GetEmployeePositionByEmployeeId(int id)
    {
        return _context.Employees.Include(e => e.EmployeePosition).First(e => e.EmployeeId == id).EmployeePosition!;
    }

    public Employee Insert(Employee entity)
    {
        _context.Employees.Add(entity);
        Save();
        return entity;
    }

    public void Update(Employee entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        Employee employee = _context.Employees.Find(id);
        _context.Employees.Remove(employee);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    #region Dispose
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
    }

    public IFilter<Employee> GetFilterData()
    {
        throw new NotImplementedException();
    }


    #endregion
}
