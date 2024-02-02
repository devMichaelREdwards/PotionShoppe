using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class EmployeePositionRepository : IRepository<EmployeePosition>, IDisposable
{
    private PotionShoppeContext context;

    public EmployeePositionRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<EmployeePosition> Get()
    {
        return [.. context.EmployeePositions];
    }

    public EmployeePosition GetById(int id)
    {
        return context.EmployeePositions.Find(id);
    }

    public EmployeePosition GetFirstByPosition(string position)
    {
        return context.EmployeePositions.First(s => s.Title == position);
    }

    public EmployeePosition Insert(EmployeePosition entity)
    {
        context.EmployeePositions.Add(entity);
        Save();
        return entity;
    }

    public void Update(EmployeePosition entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        EmployeePosition employeePosition = context.EmployeePositions.Find(id);
        context.EmployeePositions.Remove(employeePosition);
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
