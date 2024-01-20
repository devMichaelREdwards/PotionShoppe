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

    public Employee GetById(int id)
    {
        return context.Employees.Find(id);
    }

    public void Insert(Employee entity)
    {
        context.Employees.Add(entity);
    }

    public void Update(Employee entity)
    {
        context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        Employee employee = context.Employees.Find(id);
        context.Employees.Remove(employee);
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
