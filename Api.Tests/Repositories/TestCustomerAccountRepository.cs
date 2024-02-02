using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestCustomerAccountRepository : IRepository<CustomerAccount>, IDisposable
{
    private List<CustomerAccount> customerAccounts = new();
    private List<Customer> customers = new();

    public TestCustomerAccountRepository()
    {
        customers = DataFaker.FakeCustomers();
        customerAccounts = DataFaker.FakeCustomerAccounts(customers);
    }

    public IEnumerable<CustomerAccount> Get()
    {
        return customerAccounts;
    }

    public CustomerAccount GetById(int id)
    {
        return customerAccounts.Find(a => a.CustomerAccountId == id);
    }

    public CustomerAccount Insert(CustomerAccount entity)
    {
        customerAccounts.Add(entity);
        return entity;
    }

    public void Update(CustomerAccount entity)
    {
        CustomerAccount selected = customerAccounts.FirstOrDefault(
            a => a.CustomerAccountId == entity.CustomerAccountId
        )!;
        if (selected != null) { }
    }

    public void Delete(int id)
    {
        customerAccounts = customerAccounts.Where(s => s.CustomerAccountId != id).ToList();
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
