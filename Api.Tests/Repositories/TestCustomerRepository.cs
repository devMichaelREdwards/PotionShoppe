using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestCustomerRepository : IRepository<Customer>, IDisposable
{
    private List<Customer> customers = new();

    public TestCustomerRepository()
    {
        customers = DataFaker.FakeCustomers();
    }

    public IEnumerable<Customer> Get()
    {
        return customers;
    }

    public Customer GetById(int id)
    {
        return customers.Find(s => s.CustomerId == id);
    }

    public Customer Insert(Customer entity)
    {
        customers.Add(entity);
        return entity;
    }

    public void Update(Customer entity)
    {
        Customer selected = customers.FirstOrDefault(
            s => s.CustomerId == entity.CustomerId
        );
        if (selected != null)
        {
            selected.Name = entity.Name;
        }
    }

    public void Delete(int id)
    {
        customers = customers.Where(s => s.CustomerId != id).ToList();
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
