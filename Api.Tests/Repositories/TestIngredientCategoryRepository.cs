using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestIngredientCategoryRepository : IRepository<IngredientCategory>, IDisposable
{
    private List<IngredientCategory> customerStatuses = new();

    public TestIngredientCategoryRepository()
    {
        customerStatuses = DataFaker.FakeIngredientCategories();
    }

    public IEnumerable<IngredientCategory> Get()
    {
        return customerStatuses;
    }

    public IngredientCategory GetById(int id)
    {
        return customerStatuses.Find(s => s.IngredientCategoryId == id);
    }

    public IngredientCategory Insert(IngredientCategory entity)
    {
        customerStatuses.Add(entity);
        return entity;
    }

    public void Update(IngredientCategory entity)
    {
        IngredientCategory selected = customerStatuses.FirstOrDefault(
            s => s.IngredientCategoryId == entity.IngredientCategoryId
        );
        if (selected != null)
        {
            selected.Title = entity.Title;
        }
    }

    public void Delete(int id)
    {
        customerStatuses = customerStatuses.Where(s => s.IngredientCategoryId != id).ToList();
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
