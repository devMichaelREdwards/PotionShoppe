using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestEmployeeStatusRepository : IRepository<EmployeeStatus>, IDisposable
{
    private List<EmployeeStatus> employeeStatuses = new();

    public TestEmployeeStatusRepository()
    {
        employeeStatuses = DataFaker.FakeEmployeeStatuses();
    }

    public IEnumerable<EmployeeStatus> Get()
    {
        return employeeStatuses;
    }

    public EmployeeStatus GetById(int id)
    {
        return employeeStatuses.Find(s => s.EmployeeStatusId == id);
    }

    public EmployeeStatus Insert(EmployeeStatus entity)
    {
        employeeStatuses.Add(entity);
        return entity;
    }

    public void Update(EmployeeStatus entity)
    {
        EmployeeStatus selected = employeeStatuses.FirstOrDefault(
            s => s.EmployeeStatusId == entity.EmployeeStatusId
        );
        if (selected != null)
        {
            selected.Title = entity.Title;
        }
    }

    public void Delete(int id)
    {
        employeeStatuses = employeeStatuses.Where(s => s.EmployeeStatusId != id).ToList();
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
