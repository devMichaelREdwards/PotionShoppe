using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class CustomerRepository : IRepository<Customer>, IDisposable
{
    private PotionShoppeContext context;

    public CustomerRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<Customer> Get()
    {
        return [.. context.Customers.Include(c => c.CustomerStatus)];
    }

        public IEnumerable<Customer> GetListing()
    {
        return [.. context.Customers.Include(c => c.CustomerStatus).Include(c => c.CustomerAccounts)];
    }

    public Customer GetById(int id)
    {
        return context.Customers.Find(id);
    }

    public Customer Insert(Customer entity)
    {
        context.Customers.Add(entity);
        Save();
        return entity;
    }

    public void Update(Customer entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        Customer Customer = context.Customers.Find(id);
        context.Customers.Remove(Customer);
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
