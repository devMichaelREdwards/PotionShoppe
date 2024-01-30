using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class CustomerAccountRepository : IRepository<CustomerAccount>, IDisposable
{
    private PotionShoppeContext context;

    public CustomerAccountRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<CustomerAccount> Get()
    {
        return null;
        //return [.. context.CustomerAccounts.Include(e => e.CustomerAccountStatus)];
    }

    public CustomerAccount GetById(int id)
    {
        return null;
        //return context.CustomerAccounts.Find(id);
    }

    public CustomerAccount Insert(CustomerAccount entity)
    {
        return null;
        //context.CustomerAccounts.Add(entity);
        Save();
        return entity;
    }

    public void Update(CustomerAccount entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        //CustomerAccount CustomerAccount = context.CustomerAccounts.Find(id);
        //context.CustomerAccounts.Remove(CustomerAccount);
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
