using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestReceiptRepository : IListingRepository<Receipt>, IDisposable
{
    private List<Receipt> receipts = new();

    public TestReceiptRepository()
    {
        receipts = DataFaker.FakeReceipts();
    }

    public IEnumerable<Receipt> Get()
    {
        return receipts;
    }

    public Receipt GetById(int id)
    {
        return receipts.Find(s => s.ReceiptId == id);
    }

    public Receipt Insert(Receipt entity)
    {
        receipts.Add(entity);
        return entity;
    }

    public void Update(Receipt entity)
    {
        Receipt selected = receipts.FirstOrDefault(
            s => s.ReceiptId == entity.ReceiptId
        );
        if (selected != null)
        {
            selected.DateFulfilled = entity.DateFulfilled;
        }
    }

    public void Delete(int id)
    {
        receipts = receipts.Where(s => s.ReceiptId != id).ToList();
    }

    public void Save()
    {
        // Not needed for testing
    }

    #region Dispose
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing) { }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
    }

    public IEnumerable<Receipt> GetListing(IFilter<Receipt>? filter = null, Pagination? page = null, SortOrder? sortOrder = null)
    {
        return receipts;
    }

    public IFilter<Receipt> GetFilterData()
    {
        throw new NotImplementedException();
    }

    #endregion
}
