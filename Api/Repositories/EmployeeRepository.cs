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

    public IEnumerable<Employee> GetListing(IFilter<Employee>? filter = null, Pagination? page = null)
    {
        var employees = _context.Employees
            .Include(e => e.EmployeeStatus)
            .Include(e => e.EmployeePosition)
            .Include(e => e.EmployeeAccounts)
            .AsQueryable();
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
