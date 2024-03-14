using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public interface ICustomerAccountRepository : IRepository<CustomerAccount>
{
    CustomerAccount GetByUserName();
}

public class CustomerAccountRepository : IRepository<CustomerAccount>, IDisposable
{
    private PotionShoppeContext context;

    public CustomerAccountRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<CustomerAccount> Get()
    {
        return [.. context.CustomerAccounts.Include(ca => ca.Customer).ThenInclude(c => c.CustomerStatus)];
    }

    public IEnumerable<CustomerAccount> GetListing(IFilter<CustomerAccount>? filter = null, Pagination? page = null)
    {
        throw new NotImplementedException();
    }

    public CustomerAccount? GetById(int id)
    {
        return context.CustomerAccounts.Find(id);
    }

    public CustomerAccount GetByUserName(string userName)
    {
        return context.CustomerAccounts.First(ca => ca.UserName == userName);
    }

    public CustomerAccount Insert(CustomerAccount entity)
    {
        context.CustomerAccounts.Add(entity);
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
        CustomerAccount CustomerAccount = context.CustomerAccounts.Find(id);
        context.CustomerAccounts.Remove(CustomerAccount);
        Save();
    }

    public bool CustomerExists(string userName)
    {
        return context.CustomerAccounts.FirstOrDefault(a => a.UserName == userName) != null;
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
