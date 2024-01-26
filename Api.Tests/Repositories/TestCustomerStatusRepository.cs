using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestCustomerStatusRepository : IRepository<CustomerStatus>, IDisposable
{
    private List<CustomerStatus> customerStatuses = new();

    public TestCustomerStatusRepository()
    {
        customerStatuses = DataFaker.FakeCustomerStatuses();
    }

    public IEnumerable<CustomerStatus> Get()
    {
        return customerStatuses;
    }

    public CustomerStatus GetById(int id)
    {
        return customerStatuses.Find(s => s.CustomerStatusId == id);
    }

    public CustomerStatus Insert(CustomerStatus entity)
    {
        customerStatuses.Add(entity);
        return entity;
    }

    public void Update(CustomerStatus entity)
    {
        CustomerStatus selected = customerStatuses.FirstOrDefault(
            s => s.CustomerStatusId == entity.CustomerStatusId
        );
        if (selected != null)
        {
            selected.Title = entity.Title;
        }
    }

    public void Delete(int id)
    {
        customerStatuses = customerStatuses.Where(s => s.CustomerStatusId != id).ToList();
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
