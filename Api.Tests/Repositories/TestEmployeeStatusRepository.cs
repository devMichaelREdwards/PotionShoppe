using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestEmployeeStatusRepository : IRepository<EmployeeStatus>, IDisposable
{
    public IEnumerable<EmployeeStatus> Get()
    {
        return DataFaker.FakeEmployeeStatuses();
    }

    public EmployeeStatus GetById(int id)
    {
        return new EmployeeStatus() { EmployeeStatusId = id, Title = "Test" };
    }

    public EmployeeStatus Insert(EmployeeStatus entity)
    {
        return entity;
    }

    public void Update(EmployeeStatus entity) { }

    public void Delete(int id) { }

    public void Save() { }

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
