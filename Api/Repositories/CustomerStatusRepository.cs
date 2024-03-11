using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class CustomerStatusRepository : IRepository<CustomerStatus>, IDisposable
{
    private PotionShoppeContext context;

    public CustomerStatusRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<CustomerStatus> Get()
    {
        return [.. context.CustomerStatuses];
    }

    public IEnumerable<CustomerStatus> GetListing(IFilter<CustomerStatus>? filter = null)
    {
        throw new NotImplementedException();
    }


    public CustomerStatus GetById(int id)
    {
        return context.CustomerStatuses.Find(id)!;
    }

    public CustomerStatus GetFirstByStatus(string status)
    {
        return context.CustomerStatuses.First(s => s.Title == status);
    }

    public CustomerStatus Insert(CustomerStatus entity)
    {
        context.CustomerStatuses.Add(entity);
        Save();
        return entity;
    }

    public void Update(CustomerStatus entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        CustomerStatus customerStatus = context.CustomerStatuses.Find(id);
        context.CustomerStatuses.Remove(customerStatus);
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
