using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestOrderStatusRepository : IRepository<OrderStatus>, IDisposable
{
    private List<OrderStatus> employeeStatuses = new();

    public TestOrderStatusRepository()
    {
        employeeStatuses = DataFaker.FakeOrderStatuses();
    }

    public IEnumerable<OrderStatus> Get()
    {
        return employeeStatuses;
    }

    public OrderStatus GetById(int id)
    {
        return employeeStatuses.Find(s => s.OrderStatusId == id);
    }

    public OrderStatus Insert(OrderStatus entity)
    {
        employeeStatuses.Add(entity);
        return entity;
    }

    public void Update(OrderStatus entity)
    {
        OrderStatus selected = employeeStatuses.FirstOrDefault(
            s => s.OrderStatusId == entity.OrderStatusId
        );
        if (selected != null)
        {
            selected.Title = entity.Title;
        }
    }

    public void Delete(int id)
    {
        employeeStatuses = employeeStatuses.Where(s => s.OrderStatusId != id).ToList();
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

    #endregion
}
