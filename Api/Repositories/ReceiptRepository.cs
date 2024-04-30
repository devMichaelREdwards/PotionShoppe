using Api.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace Api.Data;

public class ReceiptRepository : IListingRepository<Receipt>, IDisposable
{
    private PotionShoppeContext context;

    public ReceiptRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<Receipt> Get()
    {
        return [.. context.Receipts
                    .Include(r => r.Order)
                    .Include(r => r.Employee).ThenInclude(e => e!.EmployeePosition)
                    .Include(r => r.Employee).ThenInclude(e => e!.EmployeeStatus)

                ];
    }

    public IEnumerable<Receipt> GetListing(IFilter<Receipt>? filter = null, Pagination? page = null, SortOrder? sortOrder = null)
    {
        var receipts = context.Receipts
                    .Include(r => r.Order).ThenInclude(o => o!.Customer)
                    .Include(r => r.Employee)
                    .AsQueryable();
        return receipts.ToPagedList(page?.Page ?? 1, page?.Limit ?? 20);
    }

    public Receipt? GetById(int id)
    {
        return context.Receipts!.Find(id)!;
    }

    public Receipt Insert(Receipt entity)
    {
        context.Receipts.Add(entity);
        Save();
        return entity;
    }

    public void Update(Receipt entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        Receipt receipt = context.Receipts.Find(id)!;
        context.Receipts.Remove(receipt);
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

    public IFilter<Receipt> GetFilterData()
    {
        throw new NotImplementedException();
    }

    #endregion
}
