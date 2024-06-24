using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestOrderRepository : IListingRepository<Order>, IDisposable
{
    private List<Order> orders = new();

    public TestOrderRepository()
    {
        orders = DataFaker.FakeOrders();
    }

    public IEnumerable<Order> Get()
    {
        return orders;
    }

    public Order GetById(int id)
    {
        return orders.Find(s => s.OrderId == id);
    }

    public Order Insert(Order entity)
    {
        orders.Add(entity);
        return entity;
    }

    public void Update(Order entity)
    {
        Order selected = orders.FirstOrDefault(
            s => s.OrderId == entity.OrderId
        );
        if (selected != null)
        {
            selected.OrderStatusId = entity.OrderStatusId;
        }
    }

    public void Delete(int id)
    {
        orders = orders.Where(s => s.OrderId != id).ToList();
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

    public IEnumerable<Order> GetListing(IFilter<Order>? filter = null, Pagination? page = null, SortOrder? sortOrder = null)
    {
        return orders;
    }

    public IFilter<Order> GetFilterData()
    {
        throw new NotImplementedException();
    }

    #endregion
}
