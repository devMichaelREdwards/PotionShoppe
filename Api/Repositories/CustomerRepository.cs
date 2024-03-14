using Api.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace Api.Data;

public class CustomerRepository : IListingRepository<Customer>, IDisposable
{
    private PotionShoppeContext _context;

    public CustomerRepository(PotionShoppeContext context)
    {
        _context = context;
    }

    public IEnumerable<Customer> Get()
    {
        var customers = _context.Customers.Include(c => c.CustomerStatus).Include(c => c.CustomerAccounts).AsQueryable();
        return [.. customers];
    }

    public IEnumerable<Customer> GetListing(IFilter<Customer>? filter = null, Pagination? page = null)
    {
        var customers = _context.Customers.Include(c => c.CustomerStatus).Include(c => c.CustomerAccounts).AsQueryable();
        return customers.ToPagedList(page?.Page ?? 1, page?.Limit ?? 20);
    }

    public Customer? GetById(int id)
    {
        return _context.Customers.Find(id);
    }

    public Customer Insert(Customer entity)
    {
        _context.Customers.Add(entity);
        Save();
        return entity;
    }

    public void Update(Customer entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        Customer Customer = _context.Customers.Find(id);
        _context.Customers.Remove(Customer);
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

    public IFilter<Customer> GetFilterData()
    {
        throw new NotImplementedException();
    }

    #endregion
}
