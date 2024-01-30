using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class EmployeeAccountRepository : IRepository<EmployeeAccount>, IDisposable
{
    private PotionShoppeContext context;

    public EmployeeAccountRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<EmployeeAccount> Get()
    {
        return [];
        //return [.. context.EmployeeAccounts.Include(e => e.Employee).ThenInclude(e => e.EmployeeAccountStatus)];
    }

    public EmployeeAccount GetById(int id)
    {
        return null;
        //return context.EmployeeAccounts.Find(id);
    }

    public EmployeeAccount Insert(EmployeeAccount entity)
    {
        return null;
        //context.EmployeeAccounts.Add(entity);
        Save();
        return entity;
    }

    public void Update(EmployeeAccount entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        //EmployeeAccount EmployeeAccount = context.EmployeeAccounts.Find(id);
        //context.EmployeeAccounts.Remove(EmployeeAccount);
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
