using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestEmployeeRepository : IRepository<Employee>, IDisposable
{
    public IEnumerable<Employee> Get()
    {
        return DataFaker.FakeEmployees();
    }

    public Employee GetById(int id)
    {
        return null;
    }

    public Employee Insert(Employee entity)
    {
        return entity;
    }

    public void Update(Employee entity) { }

    public void Delete(int id) { }

    public void Save() { }

    #region Dispose
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing) { }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
    }

    #endregion
}
