using Api.Controllers;
using Api.Data;
using Api.Models;
using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Api.Tests;

public class EmployeeControllerTest
{
    TestEmployeeRepository employees;
    IMapper mapper;

    public EmployeeControllerTest()
    {
        // Setup
        employees = new TestEmployeeRepository();
        mapper = MapperFaker.MockMapper();
    }

    [Fact]
    public async void GetEmployees_Returns_Correct_Employee_Data()
    {
        // Execute
        EmployeeController controller = new EmployeeController(employees, mapper);
        IActionResult result = await controller.GetEmployees();

        OkObjectResult ok = result as OkObjectResult;
        List<EmployeeDto> employeesResult = ok.Value as List<EmployeeDto>;
        // Assert
        Assert.Equal(DataFaker.FakeEmployees().Count, employeesResult.Count);
    }
}

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

    public void Insert(Employee entity) { }

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
