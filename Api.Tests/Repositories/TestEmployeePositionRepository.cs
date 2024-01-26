using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestEmployeePositionRepository : IRepository<EmployeePosition>, IDisposable
{
    private List<EmployeePosition> employeePositiones = new();

    public TestEmployeePositionRepository()
    {
        employeePositiones = DataFaker.FakeEmployeePositions();
    }

    public IEnumerable<EmployeePosition> Get()
    {
        return employeePositiones;
    }

    public EmployeePosition GetById(int id)
    {
        return employeePositiones.Find(s => s.EmployeePositionId == id);
    }

    public EmployeePosition Insert(EmployeePosition entity)
    {
        employeePositiones.Add(entity);
        return entity;
    }

    public void Update(EmployeePosition entity)
    {
        EmployeePosition selected = employeePositiones.FirstOrDefault(
            s => s.EmployeePositionId == entity.EmployeePositionId
        );
        if (selected != null)
        {
            selected.Title = entity.Title;
        }
    }

    public void Delete(int id)
    {
        employeePositiones = employeePositiones.Where(s => s.EmployeePositionId != id).ToList();
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
