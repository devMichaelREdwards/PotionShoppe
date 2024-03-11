using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class EmployeeRepository : IRepository<Employee>, IDisposable
{
    private PotionShoppeContext context;

    public EmployeeRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<Employee> Get()
    {
        return [.. context.Employees
            .Include(e => e.EmployeeStatus)
            .Include(e => e.EmployeePosition)];
    }

    public IEnumerable<Employee> GetListing(IFilter<Employee>? filter = null)
    {
        return [.. context.Employees
            .Include(e => e.EmployeeStatus)
            .Include(e => e.EmployeePosition)
            .Include(e => e.EmployeeAccounts)];
    }

    public Employee GetById(int id)
    {
        return context.Employees.Find(id);
    }

    public EmployeePosition GetEmployeePositionByEmployeeId(int id)
    {
        return context.Employees.Include(e => e.EmployeePosition).First(e => e.EmployeeId == id).EmployeePosition!;
    }

    public Employee Insert(Employee entity)
    {
        context.Employees.Add(entity);
        Save();
        return entity;
    }

    public void Update(Employee entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        Employee employee = context.Employees.Find(id);
        context.Employees.Remove(employee);
        Save();
    }

    public void Save()
    {
        context.SaveChanges();
    }

    #region Dispose
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
    }


    #endregion
}
