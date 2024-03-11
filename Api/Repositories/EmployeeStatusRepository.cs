using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class EmployeeStatusRepository : IRepository<EmployeeStatus>, IDisposable
{
    private PotionShoppeContext context;

    public EmployeeStatusRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<EmployeeStatus> Get()
    {
        return [.. context.EmployeeStatuses];
    }

    public IEnumerable<EmployeeStatus> GetListing(IFilter<EmployeeStatus>? filter = null)
    {
        throw new NotImplementedException();
    }

    public EmployeeStatus GetById(int id)
    {
        return context.EmployeeStatuses.Find(id);
    }
    public EmployeeStatus GetFirstByStatus(string status)
    {
        return context.EmployeeStatuses.First(s => s.Title == status);
    }

    public EmployeeStatus Insert(EmployeeStatus entity)
    {
        context.EmployeeStatuses.Add(entity);
        Save();
        return entity;
    }

    public void Update(EmployeeStatus entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        EmployeeStatus employeeStatus = context.EmployeeStatuses.Find(id);
        context.EmployeeStatuses.Remove(employeeStatus);
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
